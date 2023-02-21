using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.User;

namespace OnlineSchool.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    public static readonly List<User> _users = new();

    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? FindUserByEmail(string email)
    {
        return _users.FirstOrDefault(x => x.Email == email);
    }
}