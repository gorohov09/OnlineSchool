using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.User;

namespace OnlineSchool.App.Course.Queries.GetCourseDetails;

public class GetCourseDetailsQueryHandler
        : IRequestHandler<GetCourseDetailsQuery, ErrorOr<CourseDetailsVm>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCourseDetailsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CourseDetailsVm>> Handle
        (GetCourseDetailsQuery request,
        CancellationToken cancellationToken)
    {
        // 1. Проверка корректности Id курса
        if (!Guid.TryParse(request.СourseId, out var courseId) ||
            !Guid.TryParse(request.UserId, out var userId))
        {
            return Errors.Course.InvalidId;
        }

        var user = await _unitOfWork.Users.FindById(userId);
        if (user is null)
        {
            return Errors.User.UserNotFound;
        }

        if (user.GetTypeUser == UserType.Student)
        {
            var student = await _unitOfWork.Students.FindStudentByIdWithInformAdmissionsCourseByIdModulesLessonsTasks(user.Id, courseId);

            if (student is null)
                return Errors.User.UserNotFound;

            var course = student.InformationAdmissions.FirstOrDefault()?.Course;

            if (course is null)
                return Errors.Course.NotFound;


            var courseInformation = new CourseDetailsVm(
            course.Id.ToString(),
            course.Name,
            course.Description,
            student.InformationAdmissions.FirstOrDefault()?.GetPercentPassing(),
            course.Created,
            course.Updated,
            course.Modules.Select(module => new ModuleVm(
                module.Id.ToString(),
                module.Name,
                module.Order,
                module.Lessons.Select(lesson => new LessonVm(
                    lesson.Id.ToString(),
                    lesson.Order,
                    lesson.Name)).OrderBy(lesson => lesson.Order)
                .ToList())).OrderBy(module => module.Order).ToList());

            return courseInformation;
        }
        else
        {
            // 2. Проверим, что такой курс существует
            var course = await _unitOfWork.Courses.FindCourseByIdWithModulesLessons(courseId);
            if (course is null)
            {
                return Errors.Course.NotFound;
            }

            // 3. Формируем итоговую модель
            var courseInformation = new CourseDetailsVm(
            course.Id.ToString(),
            course.Name,
            course.Description,
            null,
            course.Created,
            course.Updated,
            course.Modules.Select(module => new ModuleVm(
                module.Id.ToString(),
                module.Name,
                module.Order,
                module.Lessons.Select(lesson => new LessonVm(
                    lesson.Id.ToString(),
                    lesson.Order,
                    lesson.Name)).OrderBy(lesson => lesson.Order)
                .ToList())).OrderBy(module => module.Order).ToList());

            return courseInformation;
        }

        
    }
}