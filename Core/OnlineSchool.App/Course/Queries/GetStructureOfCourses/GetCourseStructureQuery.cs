using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Queries.GetStructureOfCourses;

public record GetCourseStructureQuery(
    string CourseID) : IRequest<ErrorOr<CourseStructureVm>>;