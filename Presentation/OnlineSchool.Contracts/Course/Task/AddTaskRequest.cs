namespace OnlineSchool.Contracts.Course.Task;

public record AddTaskRequest(
    string Name,
    string Type,
    string Description,
    string Question,
    string Answer,
    string Answers,
    string WrongAnswers);