namespace OnlineSchool.App.Lesson.Queries.GetLessonDetails;

public record LessonDetailsVm(
    string Id,
    string Name,
    string EmbedHtmlVideo,
    List<TaskVm> Tasks);

public record TaskVm(
    string Id,
    int Order,
    string Type,
    string Name,
    string Description,
    string Question,
    string RightAnswer);
