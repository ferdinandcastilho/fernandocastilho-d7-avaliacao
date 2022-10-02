using System.Linq;

namespace LoginScreenApp.DataContext.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDataContext _appDataContext;
    public UserRepository(AppDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public bool AuthenticateUser(string userName, string password)
    {
        return _appDataContext.Users.AsEnumerable().FirstOrDefault(u => u.UserName == userName && u.Password == password, null) is not null;
    }
}