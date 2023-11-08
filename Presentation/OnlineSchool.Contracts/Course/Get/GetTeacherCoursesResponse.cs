namespace OnlineSchool.Contracts.Course.Get;

public record GetTeacherCoursesResponse(
	List<GetCourseResponse> Courses);

public record GetCourseResponse(
	string CourseId,
	string Name,
	string Description,
	int CountStudents,
	int CountModules,
	int CountLessons,
	int CountTasks,
	DateTime Create,
	DateTime Update);



