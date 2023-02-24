using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Commands.AddTask;

public record AddTaskCommand(
    string Name,
    string Description,
    string TaskType,
    string Question,
    string RightAnswer,
    string LessonId) : IRequest<ErrorOr<string>>;