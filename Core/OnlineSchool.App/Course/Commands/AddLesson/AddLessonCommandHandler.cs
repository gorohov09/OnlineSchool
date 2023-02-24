using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Course.Commands.AddLesson;

public class AddLessonCommandHandler
    : IRequestHandler<AddLessonCommand, ErrorOr<string>>
{
    private readonly ICourseRepository _courseRepository;

    public AddLessonCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<string>> Handle(AddLessonCommand request, CancellationToken cancellationToken)
    {
        // 1. Проверка корректности Id модуля
        if (!Guid.TryParse(request.ModuleId, out var moduleId))
        {
            return Errors.Module.InvalidId;
        }

        //2. Ищес курс по Id
        var module = await _courseRepository.FindModuleById(moduleId);
        if (module is null)
        {
            return Errors.Module.NotFound;
        }

        //3. Создаем сущность модуля и добавляем в курс
        var lesson = new LessonEntity(request.Name);
        module.AddLesson(lesson);

        //4. Обновляем курс в БД
        if (await _courseRepository.UpdateModule(module))
        {
            return lesson.Id.ToString();
        }

        return Errors.Module.CouldNotSave;
    }
}
