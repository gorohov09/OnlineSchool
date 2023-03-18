using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Queries.GetCourseDetails;

public record GetCourseDetailsQuery(
        string СourseId,
        string? UserId) : IRequest<ErrorOr<CourseDetailsVm>>;
