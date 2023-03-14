using OnlineSchool.Domain.Attempt;

namespace OnlineSchool.Domain.Course.Entities;

public class TaskEntity
{
    private List<AttemptEntity> _attempts = new();

    public Guid Id { get; }

    public string TaskInformation { get; }

    public int Order { get; set; }

    public LessonEntity Lesson { get; }

    public IReadOnlyCollection<AttemptEntity> Attempts => _attempts.AsReadOnly();

    public TaskEntity(string taskInformation)
    {
        Id = Guid.NewGuid();
        TaskInformation = taskInformation;
    }

    public TaskEntity()
    {

    }

    public void SetOrder(int order) => Order = order;

    public void AddAttempt(AttemptEntity attempt)
    {
        _attempts.Add(attempt);
    }
}

