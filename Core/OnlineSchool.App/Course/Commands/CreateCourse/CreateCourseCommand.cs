using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Commands.CreateCourse;

public record CreateCourseCommand(
    string Name,
    string Description) : IRequest<ErrorOr<bool>>;