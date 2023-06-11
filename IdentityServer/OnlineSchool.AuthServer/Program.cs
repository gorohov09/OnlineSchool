using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using OnlineSchool.AuthServer;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var connectionString = builder.Configuration.GetValue<string>("DbConnection");
services.AddIdentityServer()
    .AddInMemoryApiResources(Configuration.ApiResources)
    .AddInMemoryIdentityResources(Configuration.IdentityResources)
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddInMemoryClients(Configuration.Clients)
    .AddDeveloperSigningCredential();

var app = builder.Build();



app.UseIdentityServer();
app.MapGet("/", () => "Hello World!");


app.Run();
