using ErrorOr;
using MediatR;
using OnlineSchool.App.Authentication.Common;

namespace OnlineSchool.App.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    bool IsStudent) : IRequest<ErrorOr<AuthenticationResult>>;