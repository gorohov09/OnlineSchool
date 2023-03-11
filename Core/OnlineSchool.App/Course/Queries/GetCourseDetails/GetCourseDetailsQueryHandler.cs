using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;


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
        if (!Guid.TryParse(request.СourseId, out var courseId))
        {
            return Errors.Course.InvalidId;
        }

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