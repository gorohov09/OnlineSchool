namespace OnlineSchool.Contracts.Course.Get;

public record GetPopularCoursesResponse(
    List<PopularCourseResponse> PopularCourses);

public record PopularCourseResponse(
    string CourseId,
    string Name,
    string Description,
    int CountStudents,
    int CountTasks,
    bool IsEnroll);