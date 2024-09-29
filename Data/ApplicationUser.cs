using Microsoft.AspNetCore.Identity;

namespace Task4WebExample.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public DateTime? RegisteredAt { get; set; }
    public DateTime? LastLogin { get; set; }
    public string? Name { get; set; }
    public bool? IsLocked { get; set; }
}