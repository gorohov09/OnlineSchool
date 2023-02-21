using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.User;

namespace OnlineSchool.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    public static readonly List<UserEntity> _users = new();

    public void Add(UserEntity user)
    {
        _users.Add(user);
    }

    public UserEntity? FindUserByEmail(string email)
    {
        return _users.FirstOrDefault(x => x.Email == email);
    }
}