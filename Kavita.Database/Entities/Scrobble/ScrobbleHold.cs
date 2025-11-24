using System;
using Kavita.Database.Entities.Interfaces;
using Kavita.Database.Entities.User;

namespace Kavita.Database.Entities.Scrobble;

public class ScrobbleHold : IEntityDate
{
    public int Id { get; set; }
    public int SeriesId { get; set; }
    public Series Series { get; set; }
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public DateTime Created { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime LastModified { get; set; }
    public DateTime LastModifiedUtc { get; set; }
}
