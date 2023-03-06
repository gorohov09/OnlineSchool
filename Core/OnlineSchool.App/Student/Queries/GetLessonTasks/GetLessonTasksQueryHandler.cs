using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.StudentTaskInformation;

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

        //1. Получаем задачи урока
        var lesson = await _unitOfWork.Lessons.FindLessonByIdWithTasks(lessonId);
        if (lesson is null)
        {
            return Errors.Lesson.NotFound;
        }

        var tasksIds = lesson.Tasks.Select(t => t.Id).ToList();

        //2. Получаем информацию по задачам для студента
        var tasksInformation = await _unitOfWork.StudentTasks.GetTasksStudentForLesson(studentId, tasksIds);

        //Делаем првоерку, если урок не доступен студенту
        if (tasksIds.Count != tasksInformation.Count)
            return Errors.Student.StudentNotEnrollLesson;

        //3. Формируем список для результата
        var listTaskVm = new List<TaskVm>();

        int order = 1;
        foreach (var taskInformation in tasksInformation)
            AddTaskVm(listTaskVm, taskInformation, order++);

        return new LessonTasksVm(listTaskVm);
    }

    private void AddTaskVm(List<TaskVm> tasks, StudentTaskInformationEntity taskInformation, int order)
    {
        if (taskInformation.TimeLastAttempt.Year < 2000)
            tasks.Add(new TaskVm(taskInformation.TaskId, order,
                taskInformation.Task.Name, taskInformation.IsSolve, true, null));
        else
            tasks.Add(new TaskVm(taskInformation.TaskId, order,
                taskInformation.Task.Name, taskInformation.IsSolve, false, taskInformation.TimeLastAttempt));
    }
}