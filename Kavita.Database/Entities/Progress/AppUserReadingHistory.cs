using Kavita.Database.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Kavita.Database.Entities.Progress;

/// <summary>
/// Represents a single day's worth of Reading Sessions
/// </summary>
[Index(nameof(DateUtc), IsUnique = true)]
public class AppUserReadingHistory
{
    public int Id { get; set; }
    public DateTime DateUtc { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DailyReadingData Data { get; set; }
    public IList<ClientInfoData> ClientInfoUsed { get; set; }


    public int AppUserId { get; set; }
    public virtual AppUser AppUser { get; set; }
}

public class DailyReadingData
{
    public int TotalMinutesRead { get; set; }
    public int TotalPagesRead { get; set; }
    public int TotalWordsRead { get; set; }
    public int LongestSessionMinutes { get; set; }
}
