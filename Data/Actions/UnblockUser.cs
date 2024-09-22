using Microsoft.AspNetCore.Identity;

namespace Task4WebExample.Data.Actions;

public class UnblockUsers : IUserAction
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UnblockUser(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task ExecuteAsync(ApplicationUser user)
    {
        user.IsLocked = false;
        await _userManager.UpdateAsync(user);
    }
}