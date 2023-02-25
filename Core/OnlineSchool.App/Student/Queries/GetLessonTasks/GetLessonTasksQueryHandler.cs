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
        var lesson = await _courseRepository.FindLessonByIdWithTasks(lessonId);
        if (lesson is null)
        {
            return Errors.Lesson.NotFound;
        }

        var tasksIds = lesson.Tasks.Select(t => t.Id).ToList();

        //2. Получаем информацию по задачам для студента
        var tasksInformation = await _studentTaskRepository.GetTasksStudentForLesson(studentId, tasksIds);

        //3. Формируем список для результата
        var listTaskVm = tasksInformation
            .Select(taskInform => new TaskVm(taskInform.TaskId, taskInform.IsSolve))
            .ToList();

        return new LessonTasksVm(listTaskVm);
    }
}