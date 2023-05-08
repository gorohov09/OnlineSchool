using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Teacher.Queries.GetAllStudents;

public record GetAllStudentsQuery(
    string TeacherId) : IRequest<ErrorOr<List<StudentVm>>>;