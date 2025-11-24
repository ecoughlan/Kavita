using Kavita.Database.Entities.Enums;

namespace API.Data.Misc;

public class AgeRestriction
{
    public AgeRating AgeRating { get; set; }
    public bool IncludeUnknowns { get; set; }
}
