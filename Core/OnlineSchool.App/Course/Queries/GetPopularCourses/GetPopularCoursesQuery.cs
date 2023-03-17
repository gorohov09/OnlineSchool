using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Queries.GetPopularCourses;

public record GetPopularCoursesQuery
    (string StudentId) : IRequest<ErrorOr<PopularCoursesVm>>;