using OnlineSchool.Domain.Course.Entities;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Domain.Attempt;

public class AttemptEntity
{
    public Guid Id { get; }

    public Guid StudentId { get; }

    public Guid TaskId { get; }

    public StudentEntity Student { get; }

    public TaskEntity Task { get; }

    /// <summary>
    /// Дата отправки
    /// </summary>
    public DateTime DateDispatch { get; }

    /// <summary>
    /// Ответ
    /// </summary>
    public string Answer { get; }

    public bool IsRight { get; }

    public AttemptEntity(Guid studentId, Guid taskId, DateTime dateDispatch, string answer, bool isRight)
    {
        Id = Guid.NewGuid();
        StudentId = studentId;
        TaskId = taskId;
        DateDispatch = dateDispatch;
        Answer = answer;
        IsRight = isRight;
    }

    public AttemptEntity()
    {

    }
}
