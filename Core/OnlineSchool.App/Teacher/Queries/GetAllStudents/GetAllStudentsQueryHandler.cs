using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.App.Teacher.Queries.GetAllStudents;

public class GetAllStudentsQueryHandler
    : IRequestHandler<GetAllStudentsQuery, ErrorOr<List<StudentVm>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllStudentsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<List<StudentVm>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var result = new List<StudentVm>();

        if (!Guid.TryParse(request.TeacherId, out var teacherId))
            return Errors.User.InvalidId;

        var teacher = await _unitOfWork.Teachers.GetTeacherWithCoursesStnCrsInformationStudent(teacherId);

        if (teacher is null)
            return Errors.User.UserNotFound;

        var coursesTeacher = teacher.Courses;

        int order = 1;
        var dateTime = new DateTime(1900, 1, 1);

        foreach (var course in coursesTeacher)
        {
            var students = course.GetAllStudent();

            foreach (var student in students)
            {
                var findStudentVm = result.FirstOrDefault(s => s.Id == student.Id);

                if (findStudentVm is null)
                {
                    var studentVm = new StudentVm
                    {
                        Id = student.Id,
                        Order = order,
                        BirthDay = student.BirthDay < dateTime ? null : student.BirthDay,
                        LastName = student.LastName,
                        FirstName = student.FirstName,
                        Patronymic = student?.Patronymic,
                        CoursesName = new List<string>() { course.Name }
                    };

                    result.Add(studentVm);
                }
                else
                {
                    findStudentVm.CoursesName.Add(course.Name);
                }
            }
        }

        return result;
    }
}