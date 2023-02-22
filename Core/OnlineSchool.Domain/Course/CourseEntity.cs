using OnlineSchool.Domain.Course.Entities;
using OnlineSchool.Domain.InformationAdmission;

namespace OnlineSchool.Domain.Course;

/// <summary>
/// Курс
/// </summary>
public class CourseEntity
{
    private List<InformationAdmissionEntity> _informationAdmissions = new();
    private List<ModuleEntity> _modules = new();

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
    /// Колличество заданий
    /// </summary>
    public int CountTasks { get; }

    public IReadOnlyList<InformationAdmissionEntity> InformationAdmissions => _informationAdmissions.AsReadOnly();
    public IReadOnlyList<ModuleEntity> Modules => _modules.AsReadOnly();

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

    /// <summary>
    /// Добавление модуля
    /// </summary>
    /// <param name="module"></param>
    public void AddModule(ModuleEntity module)
    {
        //Логика по установке номера курса по порядку. Подумать над вставкой курса в середину.
        //Следовательно, другие номера должны измениться
        var maxOrder = _modules.Max(m => m.Order);
        module.SetOrder(maxOrder + 1);
        _modules.Add(module);
    }
}
