namespace OnlineSchool.Contracts.Course.Task.Get;

public record GetDetailsTaskResponse(
    string TaskId,
    string Name,
    string Question,
    string Type,
    DateTime? LastAttempt,
    bool? LastResultAttempt,
    string? LastAnswerAttempt,
    AnswerResponse? Answer,
    List<AnswerResponse>? Answers,
    List<AnswerResponse>? WrongAnswers);

public record AnswerResponse(
    string Value);
