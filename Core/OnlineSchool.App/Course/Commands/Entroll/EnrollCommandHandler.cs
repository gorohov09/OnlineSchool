using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Common.Interfaces.Services;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.StudentTaskInformation;

namespace OnlineSchool.App.Course.Commands.Entroll;

public class EnrollCommandHandler
    : IRequestHandler<EnrollCommand, ErrorOr<EnrollResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public EnrollCommandHandler(IUnitOfWork unitOfWork, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task<ErrorOr<EnrollResult>> Handle(EnrollCommand request, CancellationToken cancellationToken)
    {
        //1. Проверить валидность Id курса и студента
        if (!Guid.TryParse(request.CourseId, out var courseId) 
            || !Guid.TryParse(request.StudentId, out var studentId))
            return Errors.Course.InvalidId;

        //2. Получить курс и студента, создать объект - InformationAdmission
        var course = await _unitOfWork.Courses.FindCourseByIdWithModulesLessonsTasks(courseId);
        if (course is null)
            return Errors.Course.NotFound;

        var student = await _unitOfWork.Students.FindStudentByIdWithInformAdmissions(studentId);
        if (student is null)
            return Errors.User.UserNotFound;

        //Оформляем поступление студента на курс
        if (!student.EnrollCourse(course))
            return Errors.Enroll.StudentAlreadyEnroll;

        //_unitOfWork.Students.Update(student);

        //5. Сохранить все в БД
        if (await _unitOfWork.CompleteAsync())
            return new EnrollResult(course.Id.ToString(), true);

        //6. Отправить письмо на почту
        var user = await _unitOfWork.Users.FindById(studentId);
        if(user is null)
            return Errors.User.UserNotFound;

        await _emailService.SendEmailAsync(user.Email, "Вступление на курс", "Добро пожаловать!");

        return Errors.Enroll.CouldNotEnroll;

    }
}