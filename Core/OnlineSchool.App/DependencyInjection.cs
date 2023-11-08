using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineSchool.App.Common.Behaviors;
using System.Reflection;

namespace OnlineSchool.App;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}