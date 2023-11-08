using ErrorOr;
using MediatR;
using Newtonsoft.Json;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Student.Queries.GetLessonTasks;

public class GetLessonTasksQueryHandler
    : IRequestHandler<GetLessonTasksQuery, ErrorOr<LessonTasksVm>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetLessonTasksQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<LessonTasksVm>> Handle(
        GetLessonTasksQuery request, 
        CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.LessonId, out var lessonId)
            || !Guid.TryParse(request.StudentId, out var studentId))
        {
            return Errors.Lesson.InvalidId;
        }

        //1. Сделать проверку, что студенту доступен этот курс

        //2. Получаем информацию по задачам для студента по определенному уроку
        var tasksInformation = await _unitOfWork.Tasks.GetStudentLessonTasksWithAttempts(studentId, lessonId);

        //3. Формируем список для результата
        var listTaskVm = new List<TaskVm>();

        foreach (var taskInformation in tasksInformation)
        {
            var task = JsonConvert.DeserializeObject<TaskInformation>(taskInformation.TaskInformation);
            AddTaskVm(listTaskVm, taskInformation, task.Name);
        }

        return new LessonTasksVm(listTaskVm);
    }

    private void AddTaskVm(List<TaskVm> tasks, TaskEntity task, string taskName)
    {
        if (task.Attempts.Count() == 0)
        {
            tasks.Add(new TaskVm(task.Id, task.Order, taskName, false, true, null));
        }
        else if (task.Attempts.Any(attempt => attempt.IsRight))
        {
            var lastTimeAttempt = task.Attempts.Max(attempt => attempt.DateDispatch);
            tasks.Add(new TaskVm(task.Id, task.Order, taskName, true, false, lastTimeAttempt));
        }
        else
        {
            var lastTimeAttempt = task.Attempts.Max(attempt => attempt.DateDispatch);
            tasks.Add(new TaskVm(task.Id, task.Order, taskName, false, false, lastTimeAttempt));
        }
    }
}