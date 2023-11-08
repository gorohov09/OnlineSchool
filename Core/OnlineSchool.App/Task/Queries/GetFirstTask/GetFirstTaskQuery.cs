using ErrorOr;
using MediatR;
using OnlineSchool.App.Task.Queries.Common;

namespace OnlineSchool.App.Task.Queries.GetFirstTask;

public record GetFirstTaskQuery(
    string StudentId,
    string LessonId) : IRequest<ErrorOr<TaskDetailsVm>>;
