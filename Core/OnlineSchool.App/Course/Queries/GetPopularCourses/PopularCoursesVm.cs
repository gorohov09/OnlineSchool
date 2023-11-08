namespace OnlineSchool.App.Course.Queries.GetPopularCourses;

public record PopularCoursesVm(
    List<PopularCourseVm> PopularCourses);

public record PopularCourseVm(
    string CourseId,
    string Name,
    string Description,
    int CountStudents,
    int CountTasks,
    bool IsEnroll);
