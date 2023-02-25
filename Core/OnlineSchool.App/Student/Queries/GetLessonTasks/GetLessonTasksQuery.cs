using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Student.Queries.GetLessonTasks;

public record GetLessonTasksQuery(
    string StudentId,
    string LessonId) : IRequest<ErrorOr<LessonTasksVm>>;