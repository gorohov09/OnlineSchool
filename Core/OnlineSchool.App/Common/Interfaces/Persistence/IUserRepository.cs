using OnlineSchool.Domain.User;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task Add(UserEntity user);
    Task<UserEntity?> FindUserByEmail(string email);
    Task<UserEntity?> FindUserById(Guid id);
}