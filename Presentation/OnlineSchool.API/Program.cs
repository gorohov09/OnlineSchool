using OnlineSchool.API;
using OnlineSchool.API.Common.Mapping;
using OnlineSchool.App;
using OnlineSchool.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddPresentation();

    builder.Services
        .AddCors(options =>
        {
            options.AddPolicy("AllowAllHeaders", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowAllHeaders");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

