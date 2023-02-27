namespace OnlineSchool.App.Student.Queries.GetFullCourses
{
    public record StudentCoursesVm(

        );
    public record CourseVm(
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
}
