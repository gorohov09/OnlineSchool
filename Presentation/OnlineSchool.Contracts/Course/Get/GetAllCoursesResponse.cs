namespace OnlineSchool.Contracts.Course.Get;

public record GetAllCoursesResponse(
	List<GetCourseResponse> Courses);

public record GetCourseResponse(
	string CourseId,
	string Description,
	int CountStudents,
	int CountModules,
	int CountLessons,
	int CountTasks,
	DateTime Create,
	DateTime Update);



