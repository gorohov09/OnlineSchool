namespace OnlineSchool.App.Lesson.Queries.GetLessonDetails;

public record LessonDetailsVm(
    string Id,
    string Name,
    string EmbedHtmlVideo);

public record TaskVm(
    string Id,
    int Order,
    string Name);
