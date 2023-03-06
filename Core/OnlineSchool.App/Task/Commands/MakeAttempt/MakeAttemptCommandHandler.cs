using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Common.Interfaces.Services;
using OnlineSchool.Domain.Attempt;
using OnlineSchool.Domain.Common.Errors;

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

        var task = await _unitOfWork.Tasks.GetStudentTaskWithAttempts(studentId, taskId);

        var isRightAnswer = task.RightAnswer == request.Answer;

        if (isRightAnswer && task.Attempts.All(attempt => !attempt.IsRight))
        {
            var course = await _unitOfWork.Courses.GetCourseByTaskId(task.Id);
            var studentCourseInformation = await _unitOfWork.StudentCourses.FindStudentCourse(course.Id, studentId);

            studentCourseInformation.CountCompletedTasks += 1;
        }  

        var attempt = new AttemptEntity(studentId, taskId, _dateTimeProvider.TimeNow, request.Answer, isRightAnswer);
        task.AddAttempt(attempt);

        if (await _unitOfWork.CompleteAsync())
            return new MakeAttemptResult(isRightAnswer);

        return Errors.Course.CouldNotSave;
    }
}