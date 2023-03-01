using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Student.Queries.GetCourses;

public class GetCoursesStudentQueryHandler
    : IRequestHandler<GetCoursesStudentQuery, ErrorOr<CoursesStudentVm>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCoursesStudentQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CoursesStudentVm>> Handle(
        GetCoursesStudentQuery request,
        CancellationToken cancellationToken)
    {
        // 1. Проверка корректности Id пользователя
        if (!Guid.TryParse(request.StudentId, out var studentId))
        {
            return Errors.User.InvalidId;
        }

        // 1. Проверим, что такой пользователь существует
        var student = await _unitOfWork.Students.FindStudentByIdWithInformAdmissions(studentId);
        if (student is null)
        {
            return Errors.User.UserNotFound;
        }

        //2. Преобразуем в нужный список - информация по каждому курсу для данного ученика
        var coursesInformation = student.InformationAdmissions.Select(course => new CourseVm(
            course.Course.Id,
            course.Course.Name,
            course.Course.Description,
            course.GetPercentPassing()))
            .ToList();

        //3. Формируем итоговую модель
        return new CoursesStudentVm(
            student.Id.ToString(),
            student.LastName,
            student.FirstName,
            coursesInformation);
    }
}