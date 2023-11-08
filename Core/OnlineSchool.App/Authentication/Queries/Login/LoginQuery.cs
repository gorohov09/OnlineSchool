using ErrorOr;
using MediatR;
using OnlineSchool.App.Authentication.Common;

namespace OnlineSchool.App.Authentication.Queries.Login;
public record LoginQuery(
    string Email,
    string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;