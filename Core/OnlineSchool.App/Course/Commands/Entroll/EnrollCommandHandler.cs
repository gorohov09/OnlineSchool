using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Common.Interfaces.Services;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.StudentTaskInformation;
using OnlineSchool.Domain.User;

namespace OnlineSchool.App.Course.Commands.Entroll;

public class EnrollCommandHandler
    : IRequestHandler<EnrollCommand, ErrorOr<EnrollResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;
    private readonly ILogger<EnrollCommandHandler> _logger;

    public EnrollCommandHandler(IUnitOfWork unitOfWork, IEmailService emailService,  ILogger<EnrollCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _emailService = emailService;
        _logger = logger;
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

        //5. Сохранить все в БД и отправить письмо на почту
        if (await _unitOfWork.CompleteAsync())
        {
            var user = await _unitOfWork.Users.FindById(studentId);
            if (user is null)
                return Errors.User.UserNotFound;

            var check = await _emailService.SendEmailAsync(user.Email, $"Запись на курс {course.Name}!", $"{user.FirstName}, добро пожаловать!");
            if (!check)
            {
				_logger.LogWarning($"Письмо не отправлено на почту с адресом {user.Email}. " +
					$"{user.LastName} {user.FirstName} не получил письмо. " +
					$"Дата: {DateTime.Now.AddHours(3)}.");
			}

			return new EnrollResult(course.Id.ToString(), true);
        }

        return Errors.Enroll.CouldNotEnroll;
    }
}