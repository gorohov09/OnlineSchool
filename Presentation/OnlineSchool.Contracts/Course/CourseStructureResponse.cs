namespace OnlineSchool.Contracts.Course;

public record CourseStructureResponse(
    Guid ID,
    string Name,
    List<ModuleResponse> Modules
    );

public record ModuleResponse(
    Guid ID,
    string Name,
    List<LessonResponse> Lessons
);
public record LessonResponse(
    Guid ID,
    string Name
);