using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Student.Queries.GetCourses;

public record GetCoursesStudentQuery(
    string StudentId) : IRequest<ErrorOr<CoursesStudentVm>>;