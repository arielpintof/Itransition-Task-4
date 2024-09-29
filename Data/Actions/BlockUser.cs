using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace Task4WebExample.Data.Actions;

public class BlockUser : IUserAction
{
    private readonly UserManager<ApplicationUser> _userManager;
    
    public BlockUser(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task ExecuteAsync(ApplicationUser user)
    {
        user.IsLocked = true;
        await _userManager.UpdateAsync(user);
    }
}