using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.InformationAdmission;
using OnlineSchool.Domain.StudentTaskInformation;

namespace OnlineSchool.Domain.Student;

public class StudentEntity
{
    private List<InformationAdmissionEntity> _informationAdmissions = new();
    private List<StudentTaskInformationEntity> _tasks = new();
         
    public Guid Id { get; }

    public string LastName { get; }

    public string FirstName { get; }

    public string? Patronymic { get; }

    public DateTime BirthDay { get; }

    public IReadOnlyList<InformationAdmissionEntity> InformationAdmissions => _informationAdmissions.AsReadOnly();
    public IReadOnlyCollection<StudentTaskInformationEntity> Tasks => _tasks.AsReadOnly();

    public StudentEntity(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public StudentEntity()
    {

    }

    public bool EnrollCourse(CourseEntity course)
    {
        //Если студент уже записан на этот курс, возвращаем false
        if (_informationAdmissions.Any(inf => inf.Course.Id == course.Id))
            return false;

        _informationAdmissions.Add(new InformationAdmissionEntity(this, course));

        //Получение Ids всех задач курса
        var tasksIds = course.Modules
            .SelectMany(module => module.Lessons)
            .SelectMany(lesson => lesson.Tasks)
            .Select(task => task.Id)
            .ToList();

        //Создаем информацию по всем задачам для студента
        foreach (var taskId in tasksIds)
            _tasks.Add(new StudentTaskInformationEntity(Id, taskId));

        return true;
    }

    public string GetFullName()
    {
        return Patronymic is null ? $"{LastName} {FirstName}": $"{LastName} {FirstName} {Patronymic}";
    }
}