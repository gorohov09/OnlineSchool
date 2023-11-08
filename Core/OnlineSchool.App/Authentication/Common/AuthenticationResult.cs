using OnlineSchool.Domain.User;

namespace OnlineSchool.App.Authentication.Common;

public record AuthenticationResult(string Token, string TypeUser);