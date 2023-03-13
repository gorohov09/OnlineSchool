using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Queries.GetAllCourses;

public class GetAllCoursesQueryHandler
	: IRequestHandler<GetAllCoursesQuery, ErrorOr<AllCoursesVm>>
{
	private readonly IUnitOfWork _unitOfWork;

	public GetAllCoursesQueryHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}
	public async Task<ErrorOr<AllCoursesVm>> Handle
		(GetAllCoursesQuery request, 
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
		

		var oneCourseModel = courses.Select(course => new CourseVm(
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

		var allCourseModel = new AllCoursesVm(oneCourseModel);

		return allCourseModel;
	}
}
