namespace OnlineSchool.App.Task.Queries.Common;

public record TaskDetailsVm(
    string TaskId,
    string Name,
    string Question,
    string Type,
    DateTime? LastAttempt,
    bool? LastResultAttempt,
    string? LastAnswerAttempt,
    AnswerVm? Answer,
    List<AnswerVm>? Answers,
    List<AnswerVm>? WrongAnswers);

public record AnswerVm(
    string Value);

