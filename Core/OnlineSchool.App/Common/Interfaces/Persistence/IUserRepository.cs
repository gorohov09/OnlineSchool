using OnlineSchool.Domain.User;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void Add(User user);
    User? FindUserByEmail(string email);
}