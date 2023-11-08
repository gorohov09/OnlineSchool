using ErrorOr;
using MediatR;
using Newtonsoft.Json;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Course.Commands.AddTask;

public class AddTaskCommandHandler
    : IRequestHandler<AddTaskCommand, ErrorOr<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddTaskCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<string>> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        // 1. Проверка корректности Id курса
        if (!Guid.TryParse(request.LessonId, out var lessonId))
        {
            return Errors.Lesson.InvalidId;
        }

        //2. Ищес урок по Id
        var lesson = await _unitOfWork.Lessons.FindLessonByIdWithTasks(lessonId);
        if (lesson is null)
        {
            return Errors.Lesson.NotFound;
        }

        var typeTask = request.Type switch
        {
            "freeResponse" => TypeTask.FreeResponse,
            "oneAnswer" => TypeTask.OneAnswer,
            "manyAnswer" => TypeTask.ManyAnswer,
            _ => throw new NotImplementedException()
        };

        var taskInform = new TaskInformation
        {
            Name = request.Name,
            Description = request.Description,
            Type = typeTask,
            Answer = new Answer { Value = request.Answer},
            Question = request.Question,
            WrongAnswers = typeTask == TypeTask.OneAnswer ? GetAnswers(request.WrongAnswers) : null,
            Answers = typeTask == TypeTask.ManyAnswer ? GetAnswers(request.Answers) : null
        };

        var taskInformString = JsonConvert.SerializeObject(taskInform);

        //3. Создаем сущность задачи и добавляем в курс
        var task = new TaskEntity(taskInformString);

        lesson.AddTask(task);

        _unitOfWork.Lessons.Update(lesson);

        //4. Обновляем курс в БД
        if (await _unitOfWork.CompleteAsync())
        {
            return task.Id.ToString();
        }

        return Errors.Course.CouldNotSave;
    }

    private List<Answer> GetAnswers(string answers)
    {
        var parseAnswers = answers.Split(new char[] { ' ', ',', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
        return parseAnswers.Select(x => new Answer { Value = x }).ToList();
    }
}