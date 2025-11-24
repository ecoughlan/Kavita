
using System;
using System.Collections.Generic;
using System.Globalization;
using API.Services.Tasks.Scanner.Parser;
using Kavita.Database.Entities;
using Kavita.Database.Entities.Enums;

namespace API.Extensions.EntityExtensions;

public static class ChapterExtensions
{

    extension(Chapter chapter)
    {
        public void UpdateFrom(ParserInfo info)
        {
            chapter.Files ??= new List<MangaFile>();
            chapter.IsSpecial = info.IsSpecialInfo();
            if (chapter.IsSpecial)
            {
                chapter.Number = Parser.DefaultChapter;
                chapter.MinNumber = Parser.DefaultChapterNumber;
                chapter.MaxNumber = Parser.DefaultChapterNumber;
            }
            chapter.Title = (chapter.IsSpecial && info.Format is MangaFormat.Epub or MangaFormat.Pdf)
                ? info.Title
                : Parser.RemoveExtensionIfSupported(chapter.Range);

            var specialTreatment = info.IsSpecialInfo();
            chapter.Range = specialTreatment ? info.Filename : info.Chapters;
        }

        /// <summary>
        /// Returns the Chapter Number. If the chapter is a range, returns that, formatted.
        /// </summary>
        /// <returns></returns>
        public string GetNumberTitle()
        {
            try
            {
                if (chapter.MinNumber.Is(chapter.MaxNumber))
                {
                    if (chapter.MinNumber.Is(Parser.DefaultChapterNumber) && chapter.IsSpecial)
                    {
                        return Parser.RemoveExtensionIfSupported(chapter.Title);
                    }

                    if (chapter.MinNumber.Is(0f) && !float.TryParse(chapter.Range, CultureInfo.InvariantCulture, out _))
                    {
                        return $"{chapter.Range.ToString(CultureInfo.InvariantCulture)}";
                    }

                    return $"{chapter.MinNumber.ToString(CultureInfo.InvariantCulture)}";

                }

                return $"{chapter.MinNumber.ToString(CultureInfo.InvariantCulture)}-{chapter.MaxNumber.ToString(CultureInfo.InvariantCulture)}";
            }
            catch (Exception)
            {
                return chapter.MinNumber.ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Is the Chapter representing a single Volume (volume 1.cbz). If so, Min/Max will be Default and will not be special
        /// </summary>
        /// <returns></returns>
        public bool IsSingleVolumeChapter()
        {
            return chapter.MinNumber.Is(Parser.DefaultChapterNumber) && !chapter.IsSpecial;
        }
    }

}
