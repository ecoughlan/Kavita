using API.DTOs.Scrobbling;
using Kavita.Database.Entities.Enums;

namespace API.DTOs.KavitaPlus.ExternalMetadata;
#nullable enable

/// <summary>
/// Used for matching and fetching metadata on a series
/// </summary>
public sealed record ExternalMetadataIdsDto
{
    public long? MalId { get; set; }
    public int? AniListId { get; set; }

    public string? SeriesName { get; set; }
    public string? LocalizedSeriesName { get; set; }
    public PlusMediaFormat? PlusMediaFormat { get; set; } = Kavita.Database.Entities.Enums.PlusMediaFormat.Unknown;
}
