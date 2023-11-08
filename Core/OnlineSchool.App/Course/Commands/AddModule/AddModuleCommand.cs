using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Commands.AddModule;

public record AddModuleCommand(
        string Name,
        string CourseId) : IRequest<ErrorOr<string>>;