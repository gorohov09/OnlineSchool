namespace OnlineSchool.Contracts.Course;

public record CourseStructureResponse(
    string ID,
    string Name,
    List<ModuleResponse> Modules
    );

public record ModuleResponse(
    string ID,
    string Name,
    List<LessonResponse> Lessons
);
public record LessonResponse(
    string ID,
    string Name
);