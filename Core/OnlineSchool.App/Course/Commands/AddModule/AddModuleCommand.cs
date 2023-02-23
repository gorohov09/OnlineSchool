using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Commands.AddModule;

public record AddModuleCommand(
    string CourseId,
    string Name) : IRequest<ErrorOr<string>>;