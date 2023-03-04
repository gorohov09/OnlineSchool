using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Common.Interfaces.Services;
using OnlineSchool.Domain.Common.Errors;
using OnlineSchool.Domain.StudentTaskInformation.Entities;

namespace OnlineSchool.App.Task.Commands.MakeAttempt;

public class MakeAttemptCommandHandler
    : IRequestHandler<MakeAttemptCommand, ErrorOr<MakeAttemptResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDateTimeProvider _dateTimeProvider;

    public MakeAttemptCommandHandler(IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
    {
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<MakeAttemptResult>> Handle(MakeAttemptCommand request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.StudentId, out var studentId)
            || !Guid.TryParse(request.TaskId, out var taskId))
            return Errors.Course.InvalidId;

        var taskInform = await _unitOfWork.StudentTasks.GetTaskInformStudentWithTask(studentId, taskId);

        var isRightAnswer = taskInform.Task.RightAnswer == request.Answer;

        if (isRightAnswer && taskInform.Attempts.All(attempt => !attempt.IsRight))
        {
            var course = await _unitOfWork.Courses.GetCourseByTaskId(taskInform.TaskId);
            var studentCourseInformation = await _unitOfWork.StudentCourses.FindStudentCourse(course.Id, studentId);

            studentCourseInformation.CountCompletedTasks += 1;
            taskInform.IsSolve = isRightAnswer;
        }

        taskInform.TimeLastAttempt = _dateTimeProvider.TimeNow;
        taskInform.CountAttempts += 1;
        

        var attempt = new AttemptEntity(_dateTimeProvider.TimeNow, isRightAnswer, request.Answer);
        taskInform.AddAttempt(attempt);

        if (await _unitOfWork.CompleteAsync())
            return new MakeAttemptResult(isRightAnswer);

        return Errors.Course.CouldNotSave;
    }
}