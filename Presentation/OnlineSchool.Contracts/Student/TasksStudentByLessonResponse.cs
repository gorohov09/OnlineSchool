namespace OnlineSchool.Contracts.Student;

public record TasksStudentByLessonResponse(
    List<TaskResponse> Tasks);

public record TaskResponse(
    Guid Id,
    int Order,
    string Name,
    bool IsSolve,
    bool IsFirstAttempt,
    DateTime? LastAttempt);