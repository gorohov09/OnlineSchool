using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.User;
using System;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<UserEntity>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<UserEntity?> FindUserByEmail(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }
}