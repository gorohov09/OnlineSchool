namespace OnlineSchool.Contracts.Course.Lesson;

public record GetLessonDetailsResponse(
    string Id,
    string Name,
    string EmbedHtmlVideo,
    List<TaskResponse> Tasks);

public record TaskResponse(
    string Id,
    int Order,
    string Type,
    string Name,
    string Description,
    string Question,
    string RightAnswer);
