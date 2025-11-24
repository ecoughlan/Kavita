using System.ComponentModel.DataAnnotations;
using API.Data.Migrations;
using Kavita.Database.Entities;
using Kavita.Database.Entities.Enums;
using Kavita.Database.Entities.Enums.UserPreferences;
using Kavita.Database.Entities.User;

namespace API.DTOs;

public sealed record UserReadingProfileDto
{

    public int Id { get; set; }
    public int UserId { get; init; }

    public string Name { get; init; }
    public ReadingProfileKind Kind { get; init; }

    #region MangaReader

    /// <inheritdoc cref="Kavita.Database.Entities.Enums.ReadingDirection"/>
    [Required]
    public ReadingDirection ReadingDirection { get; set; }

    /// <inheritdoc cref="Kavita.Database.Entities.Enums.ScalingOption"/>
    [Required]
    public ScalingOption ScalingOption { get; set; }

    /// <inheritdoc cref="Kavita.Database.Entities.Enums.PageSplitOption"/>
    [Required]
    public PageSplitOption PageSplitOption { get; set; }

    /// <inheritdoc cref="Kavita.Database.Entities.Enums.ReaderMode"/>
    [Required]
    public ReaderMode ReaderMode { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.AutoCloseMenu"/>
    [Required]
    public bool AutoCloseMenu { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.ShowScreenHints"/>
    [Required]
    public bool ShowScreenHints { get; set; } = true;

    /// <inheritdoc cref="AppUserReadingProfile.EmulateBook"/>
    [Required]
    public bool EmulateBook { get; set; }

    /// <inheritdoc cref="Kavita.Database.Entities.Enums.LayoutMode"/>
    [Required]
    public LayoutMode LayoutMode { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.BackgroundColor"/>
    [Required]
    public string BackgroundColor { get; set; } = "#000000";

    /// <inheritdoc cref="AppUserReadingProfile.SwipeToPaginate"/>
    [Required]
    public bool SwipeToPaginate { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.AllowAutomaticWebtoonReaderDetection"/>
    [Required]
    public bool AllowAutomaticWebtoonReaderDetection { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.WidthOverride"/>
    public int? WidthOverride { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.DisableWidthOverride"/>
    public BreakPoint DisableWidthOverride { get; set; } = BreakPoint.Never;

    #endregion

    #region EpubReader

    /// <inheritdoc cref="AppUserReadingProfile.BookReaderMargin"/>
    [Required]
    public int BookReaderMargin { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.BookReaderLineSpacing"/>
    [Required]
    public int BookReaderLineSpacing { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.BookReaderFontSize"/>
    [Required]
    public int BookReaderFontSize { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.BookReaderFontFamily"/>
    [Required]
    public string BookReaderFontFamily { get; set; } = null!;

    /// <inheritdoc cref="AppUserReadingProfile.BookReaderTapToPaginate"/>
    [Required]
    public bool BookReaderTapToPaginate { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.BookReaderReadingDirection"/>
    [Required]
    public ReadingDirection BookReaderReadingDirection { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.BookReaderWritingStyle"/>
    [Required]
    public WritingStyle BookReaderWritingStyle { get; set; }

    /// <inheritdoc cref="AppUserReadingProfile.BookThemeName"/>
    [Required]
    public string BookReaderThemeName { get; set; } = null!;

    /// <inheritdoc cref="AppUserReadingProfile.BookReaderLayoutMode"/>
    [Required]
    public BookPageLayoutMode BookReaderLayoutMode { get; set; }

    /// <inheritdoc cref="Data.Migrations.BookReaderImmersiveMode"/>
    [Required]
    public bool BookReaderImmersiveMode { get; set; } = false;

    #endregion

    #region PdfReader

    /// <inheritdoc cref="Kavita.Database.Entities.Enums.UserPreferences.PdfTheme"/>
    [Required]
    public PdfTheme PdfTheme { get; set; } = PdfTheme.Dark;

    /// <inheritdoc cref="Kavita.Database.Entities.Enums.UserPreferences.PdfScrollMode"/>
    [Required]
    public PdfScrollMode PdfScrollMode { get; set; } = PdfScrollMode.Vertical;

    /// <inheritdoc cref="Kavita.Database.Entities.Enums.UserPreferences.PdfSpreadMode"/>
    [Required]
    public PdfSpreadMode PdfSpreadMode { get; set; } = PdfSpreadMode.None;

    #endregion

}
