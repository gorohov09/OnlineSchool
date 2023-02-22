using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Student.Queries;

public record GetCoursesStudentQuery(
    string StudentId) : IRequest<ErrorOr<CoursesStudentVm>>;