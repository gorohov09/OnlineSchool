using ErrorOr;
using MediatR;
using Newtonsoft.Json;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Task.Queries.Common;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Task.Queries.GetFirstTask;

public class GetFirstTaskQueryHandler
    : IRequestHandler<GetFirstTaskQuery, ErrorOr<TaskDetailsVm>>
{
    private readonly ITaskRepository _taskRepository;

    public GetFirstTaskQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<ErrorOr<TaskDetailsVm>> Handle(GetFirstTaskQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.StudentId, out var studentId)
            || !Guid.TryParse(request.LessonId, out var lessonId))
            return Errors.Lesson.InvalidId;

        var task = await _taskRepository.GeFirstTaskWithAttemptsByLesson(studentId, lessonId);
        if (task is null)
            return Errors.Lesson.NotFound;

        var taskInformation = JsonConvert.DeserializeObject<TaskInformation>(task.TaskInformation);
        var lastAttempt = task.GetLastAttempt();

        var result = new TaskDetailsVm(
            task.Id.ToString(),
            taskInformation.Name,
            taskInformation.Question,
            taskInformation.GetTypeTask(),
            lastAttempt is not null ? lastAttempt.DateDispatch : null,
            lastAttempt is not null ? lastAttempt.IsRight : null,
            lastAttempt is not null ? lastAttempt.Answer : null,
            taskInformation?.Answer != null ? new AnswerVm(taskInformation.Answer.Value) : null,
            taskInformation?.Answers != null ? taskInformation?.Answers.Select(answer => new AnswerVm(answer.Value)).ToList() : null,
            taskInformation?.WrongAnswers != null ? taskInformation?.WrongAnswers.Select(answer => new AnswerVm(answer.Value)).ToList() : null);

        return result;
    }
}