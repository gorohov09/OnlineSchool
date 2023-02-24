using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course.Entities;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Commands.AddModule;
public class AddModuleCommandHandler
    : IRequestHandler<AddModuleCommand, ErrorOr<string>>
{
    private readonly ICourseRepository _courseRepository;

    public AddModuleCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<string>> Handle(AddModuleCommand request, CancellationToken cancellationToken)
    {
        // 1. Проверка корректности Id курса
        if (!Guid.TryParse(request.CourseId, out var courseId))
        {
            return Errors.Course.InvalidId;
        }

        //2. Ищес курс по Id
        var course = await _courseRepository.FindCourseById(courseId);
        if (course is null)
        {
            return Errors.Course.NotFound;
        }

        //3. Создаем сущность модуля и добавляем в курс
        var module = new ModuleEntity(request.Name);
        course.AddModule(module);

        //4. Обновляем курс в БД
        if (await _courseRepository.UpdateCourse(course))
        {
            return module.Id.ToString();
        }

        return Errors.Course.CouldNotSave;
    }
}

