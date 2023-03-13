using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Queries.GetAllCourses;

public class GetTeacherCoursesQueryHandler
	: IRequestHandler<GetTeacherCoursesQuery, ErrorOr<TeacherCoursesVm>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetTeacherCoursesQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<ErrorOr<TeacherCoursesVm>> Handle
		(GetTeacherCoursesQuery request, 
		CancellationToken cancellationToken)
	{
		// 1. Проверка корректности Id преподавателя
		if (!Guid.TryParse(request.TeacherId, out var teacherId))
		{
			return Errors.User.InvalidId;
		}

		// 2. Проверим, что такой преподаватель существует
		var teacher = await _unitOfWork.Teachers.FindById(teacherId);
		if (teacher is null)
		{
			return Errors.User.UserNotFound;
		}

		var courses = await _unitOfWork.Courses.FindCoursesByIdTeacherWithModulesLessonsTasksStudents(teacherId);

		var teacherCourses = courses.Select(course => new CourseVm(
			course.Id.ToString(),
			course.Name,
			course.Description,
			course.GetCountStudents(),
			course.GetCountModules(),
			course.GetCountLessons(),
			course.GetCountTasks(),
			course.Created,
			course.Updated))
			.ToList();

		return new TeacherCoursesVm(teacherCourses);
	}
}
