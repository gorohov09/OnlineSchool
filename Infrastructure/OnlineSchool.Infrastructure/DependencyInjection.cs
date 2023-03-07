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
using OnlineSchool.Infrastructure.Services.Email;
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

        var emailSettings = new EmailGoogleSettings();
        configuration.Bind(EmailGoogleSettings.SectionName, emailSettings);

        services.AddSingleton(Options.Create(youTubeSettings));
        services.AddSingleton(Options.Create(emailSettings));
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<IModuleRepository, ModuleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmailService, EmailGoogleService>();

        services.AddScoped<IYouTubeService, YouTubeService>();
        services.AddScoped<IStudentTaskRepository, StudentTaskRepository>();

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });

        return services;
    }
}