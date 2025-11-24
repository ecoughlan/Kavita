using Microsoft.AspNetCore.Identity;

namespace Kavita.Database.Entities.User;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; } = null!;
}
