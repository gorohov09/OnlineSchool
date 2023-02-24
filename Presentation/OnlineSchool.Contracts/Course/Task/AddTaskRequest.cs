namespace OnlineSchool.Contracts.Course.Task;

public record AddTaskRequest(
    string Name,
    string Description,
    string TaskType,
    string Question,
    string RightAnswer);