namespace OnlineSchool.App.Course.Queries.GetStructureOfCourses;

public record CoursesModulesLessonsVm(
    Guid ID,
    string Name,
    List<ModuleVm> Modules
 );
public record ModuleVm(
    Guid ID,
    string Name,
    List<LessonVm> Lessons
);
public record LessonVm(
    Guid ID,
    string Name
);

