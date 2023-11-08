using OnlineSchool.Domain.User;

namespace OnlineSchool.App.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(UserEntity user);
}