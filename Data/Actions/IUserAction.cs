namespace Task4WebExample.Data.Actions;

public interface IUserAction
{
    Task ExecuteAsync(ApplicationUser user);
}