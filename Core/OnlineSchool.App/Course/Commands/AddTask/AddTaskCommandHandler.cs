using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Course.Commands.AddTask;

public class AddTaskCommandHandler
    : IRequestHandler<AddTaskCommand, ErrorOr<string>>
{
    private readonly ICourseRepository _courseRepository;

    public AddTaskCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<ErrorOr<string>> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        // 1. Проверка корректности Id курса
        if (!Guid.TryParse(request.LessonId, out var lessonId))
        {
            return Errors.Lesson.InvalidId;
        }

        //2. Ищес урок по Id
        var lesson = await _courseRepository.FindLessonById(lessonId);
        if (lesson is null)
        {
            return Errors.Lesson.NotFound;
        }

        //3. Создаем сущность задачи и добавляем в курс
        var task = new TaskEntity(request.Name, request.Description, request.TaskType,
            request.Question, request.RightAnswer);

        lesson.AddTask(task);

        //4. Обновляем курс в БД
        if (await _courseRepository.UpdateLesson(lesson))
        {
            return task.Id.ToString();
        }

        return Errors.Course.CouldNotSave;
    }
}