using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course.Entities;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Course.Commands.AddModule;
public class AddModuleCommandHandler
    : IRequestHandler<AddModuleCommand, ErrorOr<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddModuleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<string>> Handle(AddModuleCommand request, CancellationToken cancellationToken)
    {
        // 1. Проверка корректности Id курса
        if (!Guid.TryParse(request.CourseId, out var courseId))
        {
            return Errors.Course.InvalidId;
        }

        //2. Ищем курс по Id
        var course = await _unitOfWork.Courses.FindCourseByIdWithModules(courseId);
        if (course is null)
        {
            return Errors.Course.NotFound;
        }

        //3. Создаем сущность модуля и добавляем в курс
        var module = new ModuleEntity(request.Name);
        course.AddModule(module);

        //!Важно! Посмотреть у курса tracking значение, чтобы проверить, нужно ли вызывать метод update. Пока вызываем
        _unitOfWork.Courses.Update(course);

        //4. Обновляем курс в БД
        if (await _unitOfWork.CompleteAsync())
        {
            return module.Id.ToString();
        }

        return Errors.Course.CouldNotSave;
    }
}

