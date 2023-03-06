using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Commands.Enroll;

public class EnrollCommandHandler
    : IRequestHandler<EnrollCommand, ErrorOr<EnrollResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public EnrollCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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

        return Errors.Enroll.CouldNotEnroll;

    }
}