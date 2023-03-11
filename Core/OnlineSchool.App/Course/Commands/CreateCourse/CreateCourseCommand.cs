using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Commands.CreateCourse;

public record CreateCourseCommand(
    string TeacherId,
    string Name,
    string Description) : IRequest<ErrorOr<bool>>;