using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Commands.AddTask;

public record AddTaskCommand(
    string Name,
    string Type,
    string Description,
    string Question,
    string Answer,
    string Answers,
    string WrongAnswers,
    string LessonId) : IRequest<ErrorOr<string>>;