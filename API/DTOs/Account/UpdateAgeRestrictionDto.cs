using System.ComponentModel.DataAnnotations;
using Kavita.Database.Entities.Enums;

namespace API.DTOs.Account;

public sealed record UpdateAgeRestrictionDto
{
    [Required]
    public AgeRating AgeRating { get; set; }
    [Required]
    public bool IncludeUnknowns { get; set; }
}
