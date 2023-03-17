using ErrorOr;
using MediatR;
using Newtonsoft.Json;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Task.Queries.Common;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Task.Queries.GetDetailsTask;

public class GetDetailsTaskQueryHandler
    : IRequestHandler<GetDetailsTaskQuery, ErrorOr<TaskDetailsVm>>
{
    private readonly ITaskRepository _taskRepository;

    public GetDetailsTaskQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<ErrorOr<TaskDetailsVm>> Handle(GetDetailsTaskQuery request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.StudentId, out var studentId)
            || !Guid.TryParse(request.TaskId, out var taskId))
            return Errors.User.InvalidId;

        var task = await _taskRepository.GetStudentTaskWithAttempts(studentId, taskId);
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
