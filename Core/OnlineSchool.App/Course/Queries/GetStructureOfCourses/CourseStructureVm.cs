namespace OnlineSchool.App.Course.Queries.GetStructureOfCourses;

public record CourseStructureVm(
    string ID,
    string Name,
    List<ModuleVm> Modules
    );

public record ModuleVm(
    string ID,
    string Name,
    List<LessonVm> Lessons
);
public record LessonVm(
    string ID,
    string Name
);

