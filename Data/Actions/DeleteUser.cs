using Microsoft.AspNetCore.Identity;

namespace Task4WebExample.Data.Actions;

public class DeleteUser : IUserAction
{
    private readonly UserManager<ApplicationUser> _userManager;

    public DeleteUser(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task ExecuteAsync(ApplicationUser user) => await _userManager.DeleteAsync(user);
   
}