using Microsoft.AspNetCore.Identity;

namespace Task4WebExample.Data.Actions;

public class BlockUsers : IUserAction
{
    private readonly UserManager<ApplicationUser> _userManager;
    
    public BlockUsers(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task ExecuteAsync(ApplicationUser user)
    {
        user.IsLocked = true;
        await _userManager.UpdateAsync(user);
    }
}