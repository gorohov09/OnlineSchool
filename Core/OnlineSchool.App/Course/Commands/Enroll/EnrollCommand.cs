using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Commands.Enroll;

public record EnrollCommand(string StudentId,
    string CourseId) : IRequest<ErrorOr<EnrollResult>>;