using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Task4WebExample.Data.Utils;

public static class AuthUtils
{
    public static string? GetUserIdFromClaims(ClaimsPrincipal? user)
    {
        if (user?.Identity?.IsAuthenticated == true)
        {
            return user.FindFirst(claim => claim.Type == "sub")?.Value
                   ?? user.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        return null; 
    }
    
    public static async Task<bool> IsUserBlockedAsync(UserManager<ApplicationUser> userManager, ClaimsPrincipal user)
    {
        var userId = GetUserIdFromClaims(user);
        if (userId is null) return false;

        var appUser = await userManager.FindByIdAsync(userId);
        return appUser?.IsLocked == true;
    }
    
    
}