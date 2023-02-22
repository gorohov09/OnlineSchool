using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineSchool.App.Common.Interfaces.Authentication;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Common.Interfaces.Services;
using OnlineSchool.Infrastructure.Authentication;
using OnlineSchool.Infrastructure.Persistence;
using OnlineSchool.Infrastructure.Persistence.Repositories;
using OnlineSchool.Infrastructure.Services;

namespace OnlineSchool.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddDbContext<OnlineSchoolDbContext>(options =>
        {
            options.UseSqlServer("Data Source=LAPTOP-IGE01LPP\\SQLEXPRESS;Initial Catalog=OnlineSchoolDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        });

        return services;
    }
}