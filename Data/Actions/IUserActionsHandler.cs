using Task4WebExample.Components.Pages;

namespace Task4WebExample.Data.Actions;

public interface IUserActionsHandler
{
    Task ExecuteUserAction(IUserAction action, IEnumerable<Auth.Person> selectedUsers);
    
}