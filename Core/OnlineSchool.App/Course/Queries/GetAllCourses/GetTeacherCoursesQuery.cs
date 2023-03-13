using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Queries.GetAllCourses;

public record GetTeacherCoursesQuery(
	string TeacherId) : IRequest<ErrorOr<TeacherCoursesVm>>;
