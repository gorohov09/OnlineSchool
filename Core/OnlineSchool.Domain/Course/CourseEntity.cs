using OnlineSchool.Domain.InformationAdmission;

namespace OnlineSchool.Domain.Course;

/// <summary>
/// Курс
/// </summary>
public class CourseEntity
{
    private List<InformationAdmissionEntity> _informationAdmissions = new();

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime Created { get; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTime Updated { get; }

    /// <summary>
    /// Колличество уроков
    /// </summary>
    public int CountLessons { get; }

    /// <summary>
    /// Колличество заданий
    /// </summary>
    public int CountTasks { get; }

    public IReadOnlyList<InformationAdmissionEntity> InformationAdmissions => _informationAdmissions.AsReadOnly();

    public CourseEntity(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;  
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    public CourseEntity()
    {

    }
}
