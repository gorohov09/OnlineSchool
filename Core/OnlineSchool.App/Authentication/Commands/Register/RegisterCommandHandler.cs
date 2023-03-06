using ErrorOr;
using MediatR;
using OnlineSchool.App.Authentication.Common;
using OnlineSchool.App.Common.Interfaces.Authentication;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Student;
using OnlineSchool.Domain.User;

namespace OnlineSchool.App.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(
        IUnitOfWork unitOfWork,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _unitOfWork = unitOfWork;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.Users.FindUserByEmail(request.Email) is not null)
        {
            return Errors.Authentication.DuplicateEmail;
        }

        var user = new UserEntity(request.FirstName, request.LastName,
            request.Password, request.Email);

        await _unitOfWork.Users.Add(user);

        if (request.IsStudent)
        {
            var student = new StudentEntity(user.Id, user.FirstName, user.LastName);
            await _unitOfWork.Students.Add(student);
        }

        await _unitOfWork.CompleteAsync();

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName, request.IsStudent);

        return new AuthenticationResult(token);
    }
}
