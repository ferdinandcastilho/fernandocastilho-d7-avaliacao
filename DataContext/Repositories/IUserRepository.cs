namespace LoginScreenApp.DataContext.Repositories;

public interface IUserRepository
{
    bool AuthenticateUser(string userName, string password);
}