using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.StudentTaskInformation;

namespace OnlineSchool.App.Course.Commands.Entroll;

public class EnrollCommandHandler
    : IRequestHandler<EnrollCommand, ErrorOr<EnrollResult>>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;

    public EnrollCommandHandler(
        ICourseRepository courseRepository,
        IStudentRepository studentRepository)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
    }

    public async Task<ErrorOr<EnrollResult>> Handle(EnrollCommand request, CancellationToken cancellationToken)
    {
        //1. Проверить валидность Id курса и студента
        if (!Guid.TryParse(request.CourseId, out var courseId) 
            || !Guid.TryParse(request.StudentId, out var studentId))
            return Errors.Course.InvalidId;

        //2. Получить курс и студента, создать объект - InformationAdmission
        var course = await _courseRepository.FindCourseById(courseId);
        if (course is null)
            return Errors.Course.NotFound;

        var student = await _studentRepository.FindStudentById(studentId);
        if (student is null)
            return Errors.Course.NotFound;

        //Оформляем поступление студента на курс
        if (!student.EnrollCourse(course))
            return Errors.Enroll.StudentAlreadyEnroll;

        //5. Сохранить все в БД
        if (await _studentRepository.UpdateStudent(student))
            return new EnrollResult(course.Id.ToString(), true);

        return Errors.Enroll.CouldNotEnroll;

    }
}