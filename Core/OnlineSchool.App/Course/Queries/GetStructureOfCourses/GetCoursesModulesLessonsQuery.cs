

using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Queries.GetStructureOfCourses;

public record GetCoursesModulesLessonsQuery(
    string StudentID, string CourseID) : IRequest<ErrorOr<CoursesModulesLessonsVm>>;