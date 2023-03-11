using OnlineSchool.Domain.Course;

namespace OnlineSchool.Domain.Teacher;

public class TeacherEntity
{
    private List<CourseEntity> _courses = new();

    public Guid Id { get; }

    public string LastName { get; }

    public string FirstName { get; }

    public string? Patronymic { get; }

    public DateTime BirthDay { get; }

    public IReadOnlyList<CourseEntity> Courses => _courses.AsReadOnly();

    public TeacherEntity()
    {

    }

    public TeacherEntity(Guid id, string lastName, string firstName)
    {
        Id = id;
        LastName = lastName;
        FirstName = firstName;
    }

    public void AddCourse(CourseEntity course)
    {
        _courses.Add(course);
    }
}
