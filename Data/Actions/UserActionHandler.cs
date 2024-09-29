using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Task4WebExample.Components.Pages;
using Task4WebExample.Data.Utils;

namespace Task4WebExample.Data.Actions;

public class UserActionHandler : IUserActionsHandler
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly NavigationManager _navigation;
    private Task<AuthenticationState>? AuthenticationState { get; set; }

    public UserActionHandler(
        UserManager<ApplicationUser> userManager,
        NavigationManager navigation,
        Task<AuthenticationState>? authenticationState)
    {
        _userManager = userManager;
        _navigation = navigation;
        AuthenticationState = authenticationState;
    }

    public async Task ExecuteUserAction(IUserAction action, IEnumerable<Auth.Person> selectedUsers)
    {
        if (await UserShouldLogout()) return;
        
        
        Console.WriteLine("executing action");
        foreach (var user in selectedUsers)
        {
            var appUser = await _userManager.FindByIdAsync(user.ApplicationUser.Id);
            if (appUser is null) continue;

            await action.ExecuteAsync(appUser);
        }
        
    }

    private async Task<bool> UserShouldLogout()
    {
        if (AuthenticationState == null) return false;
        var authState = await AuthenticationState;
        var user = authState.User;

        var shouldLogout = await AuthUtils.IsUserBlockedAsync(_userManager, user);
        Console.WriteLine($"Should logout? : {shouldLogout}");
        if (!shouldLogout) return false;
        
        /*
        var userId = AuthUtils.GetUserIdFromClaims(user);
        var appUser = await _userManager.FindByIdAsync(userId);
        Console.WriteLine(appUser.Name);
        if (appUser.Name is not null) return false; */
        
        _navigation.NavigateTo("/Logout", true);

        return true;
    }
}