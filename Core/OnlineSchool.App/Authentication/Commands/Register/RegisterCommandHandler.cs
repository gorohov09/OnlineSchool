using ErrorOr;
using MediatR;
using OnlineSchool.App.Authentication.Common;
using OnlineSchool.App.Common.Interfaces.Authentication;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Student;
using OnlineSchool.Domain.Teacher;
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

        UserEntity user;

        if (request.IsStudent)
            user = new UserEntity(request.FirstName, request.LastName,
                request.Password, request.Email, UserType.Student);
        else
            user = new UserEntity(request.FirstName, request.LastName,
                request.Password, request.Email, UserType.Teacher);


        await _unitOfWork.Users.Add(user);

        if (user.GetTypeUser == UserType.Student)
        {
            var student = new StudentEntity(user.Id, user.FirstName, user.LastName);
            await _unitOfWork.Students.Add(student);
        }
        else
        {
            var teacher = new TeacherEntity(user.Id, user.FirstName, user.LastName);
            await _unitOfWork.Teachers.Add(teacher);
        }

        await _unitOfWork.CompleteAsync();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(token, user.GetUserTypeToString());
    }
}
