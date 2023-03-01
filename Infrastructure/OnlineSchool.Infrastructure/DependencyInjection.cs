using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OnlineSchool.App.Common.Interfaces.Authentication;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Common.Interfaces.Services;
using OnlineSchool.Infrastructure.Authentication;
using OnlineSchool.Infrastructure.Persistence;
using OnlineSchool.Infrastructure.Persistence.Repositories;
using OnlineSchool.Infrastructure.Services;
using OnlineSchool.Infrastructure.Services.YouTube;

namespace OnlineSchool.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var youTubeSettings = new YouTubeSettings();
        configuration.Bind(YouTubeSettings.SectionName, youTubeSettings);

        services.AddSingleton(Options.Create(youTubeSettings));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IYouTubeService, YouTubeService>();

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer("Data Source=LAPTOP-IGE01LPP\\SQLEXPRESS;Initial Catalog=OnlineSchoolDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        });
        //@"data source=LAPTOP-9S2AK2B9;initial catalog=OnlineSchoolDB;trusted_connection=true"
        //"Data Source=LAPTOP-IGE01LPP\\SQLEXPRESS;Initial Catalog=OnlineSchoolDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        return services;
    }
}