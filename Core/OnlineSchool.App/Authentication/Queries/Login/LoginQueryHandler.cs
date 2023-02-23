using ErrorOr;
using MediatR;
using OnlineSchool.App.Authentication.Common;
using OnlineSchool.App.Common.Interfaces.Authentication;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindUserByEmail(request.Email);
            if (user is not null)
            {
                if (user.Password == request.Password)
                {
                    var jwtToken = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
                    return new AuthenticationResult(jwtToken);
                }
            }

            return Errors.Authentication.InvalidCredentials;
        }
    }
}
