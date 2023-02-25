using OnlineSchool.Domain.Course.Entities;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Domain.StudentTaskInformation;

public class StudentTaskInformationEntity
{
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

    public StudentTaskInformationEntity(Guid userId, Guid taskId)
    {
        Id = Guid.NewGuid();
        StudentId = userId;
        TaskId = taskId;
    }

    public StudentTaskInformationEntity()
    {

    }
}