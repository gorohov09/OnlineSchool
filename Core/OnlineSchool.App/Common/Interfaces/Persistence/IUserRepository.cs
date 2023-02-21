using OnlineSchool.Domain.User;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void Add(UserEntity user);
    UserEntity? FindUserByEmail(string email);
}