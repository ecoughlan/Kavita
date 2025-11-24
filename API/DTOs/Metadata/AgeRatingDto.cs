using Kavita.Database.Entities.Enums;

namespace API.DTOs.Metadata;

public sealed record AgeRatingDto
{
    public AgeRating Value { get; set; }
    public required string Title { get; set; }
}
