using OnlineSchool.Domain.Course.Entities;
using OnlineSchool.Domain.Student;
using OnlineSchool.Domain.StudentTaskInformation.Entities;

namespace OnlineSchool.Domain.StudentTaskInformation;

public class StudentTaskInformationEntity
{
    private List<AttemptEntity> _attempts = new();

    public Guid Id { get; }

    public Guid StudentId { get; }

    public Guid TaskId { get; }

    public StudentEntity Student { get; }

    public TaskEntity Task { get; }

    /// <summary>
    /// Решена ли задача
    /// </summary>
    public bool IsSolve { get; set; }

    /// <summary>
    /// Кол-во попыток
    /// </summary>
    public int CountAttempts { get; set; }

    /// <summary>
    /// Время последней попытки
    /// </summary>
    public DateTime TimeLastAttempt { get; set; }

    public IReadOnlyList<AttemptEntity> Attempts => _attempts.AsReadOnly();

    public StudentTaskInformationEntity(Guid userId, Guid taskId)
    {
        Id = Guid.NewGuid();
        StudentId = userId;
        TaskId = taskId;
    }

    public StudentTaskInformationEntity()
    {

    }

    public void AddAttempt(AttemptEntity attempt)
    {
        _attempts.Add(attempt);
    }
}