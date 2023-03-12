using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Queries.GetAllCourses;

public record GetAllCoursesQuery(
	string TeacherId) : IRequest<ErrorOr<AllCoursesVm>>;
