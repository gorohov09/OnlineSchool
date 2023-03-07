using OnlineSchool.Domain.User;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    Task<UserEntity?> FindUserByEmail(string email);

    
}