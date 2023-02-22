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
    private readonly IUserRepository _userRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IStudentRepository studentRepository,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _studentRepository = studentRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.FindUserByEmail(request.Email) is not null)
        {
            return Errors.Authentication.DuplicateEmail;
        }

        var user = new UserEntity(request.FirstName, request.LastName,
            request.Password, request.Email);

        await _userRepository.Add(user);

        if (request.IsStudent)
        {
            var student = new StudentEntity(user.Id, user.FirstName, user.LastName);
            await _studentRepository.AddStudent(student);
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName, request.IsStudent);

        return new AuthenticationResult(token);
    }
}
