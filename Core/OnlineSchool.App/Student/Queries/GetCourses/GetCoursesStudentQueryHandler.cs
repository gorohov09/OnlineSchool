using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Student.Queries.GetCourses;

public class GetCoursesStudentQueryHandler
    : IRequestHandler<GetCoursesStudentQuery, ErrorOr<CoursesStudentVm>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUserRepository _userRepository;

    public GetCoursesStudentQueryHandler(
        IStudentRepository studentRepository,
        IUserRepository userRepository)
    {
        _studentRepository = studentRepository;
        _userRepository = userRepository;
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
        var student = await _userRepository.FindUserById(studentId);
        if (student is null)
        {
            return Errors.User.UserNotFound;
        }

        // 2. Получаем информацию по курсам, на которые зачислен ученик
        var informationAddmission = await _studentRepository.GetInformationAdmissions(studentId);

        //3. Преобразуем в нужный список - информация по каждому курсу для данного ученика
        var coursesInformation = informationAddmission.Select(course => new CourseVm(
            course.Course.Id,
            course.Course.Name,
            course.Course.Description,
            course.GetPercentPassing()))
            .ToList();

        //4. Формируем итоговую модель
        return new CoursesStudentVm(
            student.Id.ToString(),
            student.LastName,
            student.FirstName,
            coursesInformation);
    }
}