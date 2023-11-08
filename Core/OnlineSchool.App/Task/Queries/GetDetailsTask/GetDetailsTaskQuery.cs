using ErrorOr;
using MediatR;
using OnlineSchool.App.Task.Queries.Common;

namespace OnlineSchool.App.Task.Queries.GetDetailsTask;

public record GetDetailsTaskQuery(
    string StudentId,
    string TaskId) : IRequest<ErrorOr<TaskDetailsVm>>;