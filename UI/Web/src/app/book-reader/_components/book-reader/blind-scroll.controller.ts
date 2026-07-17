import {signal} from '@angular/core';
import afterFrame from 'afterframe';

const BLIND_SCROLL_SPEED_STORAGE_KEY = 'kavita.epub-reader.blind-scroll.speed';

interface BlindScrollAdapter {
  document: Document;
  getReader: () => HTMLElement | undefined;
  getPageNum: () => number;
  setPageNum: (pageNum: number) => void;
  getMaxPages: () => number;
  getPageContent: (pageNum: number) => Promise<string>;
  renderPage: (content: string, part?: string, scrollTop?: number) => Promise<void>;
  detectChanges: () => void;
  updateWidthAndHeightCalcs: () => void;
  handleScrollEvent: () => void;
  loadNextChapter: () => void;
  onStop: (wasActive: boolean) => void;
}

export class BlindScrollController {
  readonly active = signal(false);
  readonly paused = signal(false);
  readonly speed = signal(15);
  readonly bottomSpacerHeight = signal(0);

  private operationId = 0;
  private animations: Animation[] = [];
  private cycleBaseSpeed = 15;
  private lineElement?: HTMLElement;
  private speedFeedbackElement?: HTMLElement;
  private speedFeedbackStyleElement?: HTMLStyleElement;
  private speedFeedbackTimeout?: ReturnType<typeof setTimeout>;

  constructor(private readonly adapter: BlindScrollAdapter) {}

  start(): void {
    if (this.active()) return;

    this.speed.set(this.getStoredSpeed());
    this.ensureTransitionStyles();

    const document = this.adapter.document;
    this.lineElement = document.createElement('div');
    this.lineElement.className = 'blind-scroll-line';
    this.lineElement.setAttribute('aria-hidden', 'true');
    document.body.appendChild(this.lineElement);

    this.speedFeedbackElement = document.createElement('div');
    this.speedFeedbackElement.className = 'blind-scroll-speed-feedback';
    this.speedFeedbackElement.setAttribute('role', 'status');
    this.speedFeedbackElement.setAttribute('aria-live', 'polite');
    document.body.appendChild(this.speedFeedbackElement);

    this.operationId++;
    this.active.set(true);
    this.paused.set(false);
    const operationId = this.operationId;
    afterFrame(() => {
      if (!this.active() || operationId !== this.operationId) return;
      this.adapter.updateWidthAndHeightCalcs();
      void this.run(operationId);
    });
  }

  stop(): void {
    const wasActive = this.active();
    this.operationId++;
    this.active.set(false);
    this.paused.set(false);
    this.animations.forEach(animation => animation.cancel());
    this.animations = [];
    this.lineElement?.remove();
    this.lineElement = undefined;
    clearTimeout(this.speedFeedbackTimeout);
    this.speedFeedbackTimeout = undefined;
    this.speedFeedbackStyleElement?.remove();
    this.speedFeedbackStyleElement = undefined;
    this.speedFeedbackElement?.remove();
    this.speedFeedbackElement = undefined;
    this.bottomSpacerHeight.set(0);
    this.adapter.onStop(wasActive);
  }

  togglePause(): void {
    this.paused.update(p => !p);
    this.animations.forEach(animation => this.paused() ? animation.pause() : animation.play());
  }

  adjustSpeed(delta: number): void {
    const newSpeed = this.clampSpeed(this.speed() + delta);
    this.speed.set(newSpeed);
    localStorage.setItem(BLIND_SCROLL_SPEED_STORAGE_KEY, `${newSpeed}`);
    const playbackRate = newSpeed / this.cycleBaseSpeed;
    this.animations.forEach(animation => animation.updatePlaybackRate(playbackRate));
    this.showSpeedFeedback(newSpeed);
  }

  adjustProgress(direction: number): void {
    const [revealAnimation, lineAnimation] = this.animations;
    const duration = revealAnimation?.effect?.getComputedTiming().duration;
    if (typeof duration !== 'number') return;

    const currentTime = Number(revealAnimation.currentTime ?? 0);
    const nextTime = Math.max(0, Math.min(duration, currentTime + direction * duration * 0.1));
    revealAnimation.currentTime = nextTime;
    lineAnimation!.currentTime = nextTime;
  }

  destroy(): void {
    this.stop();
    this.adapter.document.getElementById('blind-scroll-view-transition-styles')?.remove();
  }

  private async run(operationId: number): Promise<void> {
    while (this.active() && operationId === this.operationId) {
      const keepGoing = await this.runCycle(operationId).catch(err => {
        console.error('Blind scroll failed', err);
        this.stop();
        return false;
      });
      if (!keepGoing) return;
    }
  }

  private async runCycle(operationId: number): Promise<boolean> {
    const reader = this.adapter.getReader();
    if (!reader) return false;

    const viewportHeight = reader.clientHeight;
    const stepHeight = Math.max(1, viewportHeight);
    const naturalMaxScrollTop = Math.max(0, reader.scrollHeight - this.bottomSpacerHeight() - reader.clientHeight);
    const remaining = Math.max(0, naturalMaxScrollTop - reader.scrollTop);
    const hasNextSection = this.adapter.getPageNum() + 1 < this.adapter.getMaxPages();

    let advance: () => void;
    let finishAdvance: (() => Promise<void>) | undefined;
    if (remaining <= 0) {
      if (hasNextSection) {
        this.lineElement!.style.visibility = 'hidden';
        const nextPage = this.adapter.getPageNum() + 1;
        const content = await this.adapter.getPageContent(nextPage);
        await this.preloadImages(content);
        if (!this.active() || operationId !== this.operationId) return false;

        let renderPromise: Promise<void> | undefined;
        advance = () => {
          this.bottomSpacerHeight.set(0);
          this.adapter.setPageNum(nextPage);
          renderPromise = this.adapter.renderPage(content, undefined, 0);
          reader.scrollTop = 0;
        };
        finishAdvance = () => renderPromise ?? Promise.resolve();
      } else {
        this.stop();
        this.adapter.loadNextChapter();
        return false;
      }
    } else {
      if (remaining < stepHeight) {
        this.bottomSpacerHeight.set(stepHeight - remaining);
        this.adapter.detectChanges();
        await new Promise<void>(resolve => afterFrame(() => resolve()));
      }

      const nextScrollTop = reader.scrollTop + stepHeight;
      advance = () => {
        reader.scrollTop = nextScrollTop;
      };
    }

    this.lineElement!.style.visibility = '';
    await this.revealAdvance(operationId, viewportHeight, advance, finishAdvance);
    if (!this.active() || operationId !== this.operationId) return false;

    this.adapter.handleScrollEvent();
    return true;
  }

  private async revealAdvance(operationId: number, viewportHeight: number, advance: () => void, finishAdvance?: () => Promise<void>): Promise<void> {
    this.cycleBaseSpeed = this.speed();
    const duration = Math.max(1, Math.round(viewportHeight / this.cycleBaseSpeed * 1000));
    const document = this.adapter.document;
    const root = document.documentElement;

    try {
      root.classList.add('blind-scroll-transition');
      const transition = document.startViewTransition(() => {
        advance();
      });
      await transition.ready;
      if (!this.active() || operationId !== this.operationId) {
        transition.skipTransition();
        return;
      }
      await finishAdvance?.();
      if (!this.active() || operationId !== this.operationId) {
        transition.skipTransition();
        return;
      }

      const animationOptions = {duration, easing: 'linear', fill: 'both'} as KeyframeAnimationOptions;
      const revealAnimation = root.animate([
        {clipPath: 'inset(0 0 100% 0)'},
        {clipPath: 'inset(0 0 0 0)'}
      ], {...animationOptions, pseudoElement: '::view-transition-new(reader-viewport)'});

      const lineAnimation = root.animate([
        {transform: 'translateY(0)'},
        {transform: `translateY(${viewportHeight}px)`}
      ], {...animationOptions, pseudoElement: '::view-transition-new(blind-scroll-line)'});
      this.animations = [revealAnimation, lineAnimation];

      const playbackRate = this.speed() / this.cycleBaseSpeed;
      this.animations.forEach(animation => animation.updatePlaybackRate(playbackRate));

      if (this.paused()) {
        this.animations.forEach(animation => animation.pause());
      }

      await Promise.all([
        ...this.animations.map(animation => animation.finished.catch(() => undefined)),
        transition.finished.catch(() => undefined)
      ]);
    } finally {
      root.classList.remove('blind-scroll-transition');
      this.animations = [];
    }
  }

  private getStoredSpeed(): number {
    return this.clampSpeed(Number(localStorage.getItem(BLIND_SCROLL_SPEED_STORAGE_KEY)) || 15);
  }

  private clampSpeed(value: number): number {
    return Math.max(1, Math.min(60, Math.round(value)));
  }

  private async preloadImages(content: string): Promise<void> {
    const ImageCtor = this.adapter.document.defaultView?.Image;
    if (!ImageCtor) return;

    const parsed = new DOMParser().parseFromString(content, 'text/html');
    const sources = [...new Set(Array.from(parsed.querySelectorAll('img[src]'))
      .map(image => image.getAttribute('src'))
      .filter((source): source is string => !!source))];
    await Promise.all(sources.map(source => new Promise<void>(resolve => {
      const timeout = setTimeout(resolve, 5_000);
      const image = new ImageCtor();
      image.onload = image.onerror = () => {
        clearTimeout(timeout);
        resolve();
      };
      image.src = new URL(source, this.adapter.document.baseURI).href;
    })));
  }

  private showSpeedFeedback(speed: number): void {
    const feedback = this.speedFeedbackElement;
    if (!feedback) return;

    feedback.textContent = `Speed: ${speed} px/sec`;
    const svg = `<svg xmlns="http://www.w3.org/2000/svg" width="180" height="48"><rect width="180" height="48" rx="4" fill="#2f96b4"/><text x="16" y="30" fill="white" font-family="system-ui, sans-serif" font-size="16">Speed: ${speed} px/sec</text></svg>`;
    if (!this.speedFeedbackStyleElement) {
      this.speedFeedbackStyleElement = this.adapter.document.createElement('style');
      this.adapter.document.head.appendChild(this.speedFeedbackStyleElement);
    }
    this.speedFeedbackStyleElement.textContent = `
      ::view-transition-new(blind-scroll-speed-feedback) {
        opacity: 1 !important;
        background: url("data:image/svg+xml,${encodeURIComponent(svg)}") center / 100% 100% no-repeat !important;
      }
    `;
    clearTimeout(this.speedFeedbackTimeout);
    this.speedFeedbackTimeout = setTimeout(() => {
      this.speedFeedbackStyleElement?.remove();
      this.speedFeedbackStyleElement = undefined;
      this.speedFeedbackTimeout = undefined;
    }, 1500);
  }

  private ensureTransitionStyles(): void {
    if (this.adapter.document.getElementById('blind-scroll-view-transition-styles')) return;

    const style = this.adapter.document.createElement('style');
    style.id = 'blind-scroll-view-transition-styles';
    style.textContent = `
      .blind-scroll-line {
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 1px;
        background-color: var(--primary-color);
        box-shadow: 0 0 2px var(--primary-color);
        pointer-events: none;
      }
      .blind-scroll-speed-feedback {
        position: fixed;
        inset: 0.75rem 0.75rem auto auto;
        width: 180px;
        height: 48px;
        margin: 0;
        opacity: 0;
        pointer-events: none;
      }
      .blind-scroll-transition .reader-container { view-transition-name: reader-viewport; }
      .blind-scroll-transition .blind-scroll-line { view-transition-name: blind-scroll-line; }
      .blind-scroll-transition .blind-scroll-speed-feedback { view-transition-name: blind-scroll-speed-feedback; }
      ::view-transition-old(root), ::view-transition-new(root) { animation: none; }
      ::view-transition-old(reader-viewport), ::view-transition-new(reader-viewport) {
        animation: none;
        mix-blend-mode: normal;
        height: 100%;
      }
      ::view-transition-old(reader-viewport) { animation-name: none; z-index: 1; }
      ::view-transition-new(reader-viewport) { z-index: 2; }
      ::view-transition-old(blind-scroll-line), ::view-transition-new(blind-scroll-line) { animation: none; }
      ::view-transition-old(blind-scroll-line) { opacity: 0; }
      ::view-transition-new(blind-scroll-line) { z-index: 3; }
      ::view-transition-group(blind-scroll-speed-feedback) { animation: none; z-index: 4; }
      ::view-transition-old(blind-scroll-speed-feedback), ::view-transition-new(blind-scroll-speed-feedback) { animation: none; opacity: 0; }
    `;
    this.adapter.document.head.appendChild(style);
  }
}
