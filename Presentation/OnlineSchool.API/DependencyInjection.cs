using OnlineSchool.API.Common.Mapping;

namespace OnlineSchool.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMappings();
        return services;
    }
}
