using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Common.Errors;

namespace OnlineSchool.App.Student.Queries.GetLessonTasks;

public class GetLessonTasksQueryHandler
    : IRequestHandler<GetLessonTasksQuery, ErrorOr<LessonTasksVm>>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentTaskRepository _studentTaskRepository;

    public GetLessonTasksQueryHandler(
        ICourseRepository courseRepository,
        IStudentTaskRepository studentTaskRepository)
    {
        _courseRepository = courseRepository;
        _studentTaskRepository = studentTaskRepository;
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
        var lesson = await _courseRepository.FindLessonById(lessonId);
        if (lesson is null)
        {
            return Errors.Lesson.NotFound;
        }

        var tasksIds = lesson.Tasks.Select(t => t.Id).ToList();

        //2. Получаем информацию по задачам для студента
        var tasksInformation = await _studentTaskRepository.GetTasksStudentForLesson(studentId, tasksIds);

        //Делаем првоерку, если урок не доступен студенту
        if (tasksIds.Count != tasksInformation.Count)
            return Errors.Student.StudentNotEnrollLesson;

        //3. Формируем список для результата
        var listTaskVm = new List<TaskVm>();

        int order = 1;
        foreach (var taskInformation in tasksInformation)
        {
            listTaskVm.Add(new TaskVm(taskInformation.TaskId, order, 
                taskInformation.Task.Name, taskInformation.IsSolve));

            order++;
        }

        return new LessonTasksVm(listTaskVm);
    }
}