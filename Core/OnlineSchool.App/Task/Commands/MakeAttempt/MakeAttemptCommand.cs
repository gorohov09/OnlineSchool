using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Task.Commands.MakeAttempt;

public record MakeAttemptCommand(
    string StudentId,
    string TaskId,
    string Answer) : IRequest<ErrorOr<MakeAttemptResult>>;
