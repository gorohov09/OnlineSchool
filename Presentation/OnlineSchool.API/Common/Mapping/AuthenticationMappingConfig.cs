using Mapster;
using OnlineSchool.App.Authentication.Commands.Register;
using OnlineSchool.App.Authentication.Common;
using OnlineSchool.Contracts.Authentication;

namespace OnlineSchool.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>();
        config.NewConfig<RegisterRequest, RegisterCommand>();
    }
}