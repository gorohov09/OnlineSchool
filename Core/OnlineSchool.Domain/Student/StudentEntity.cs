using OnlineSchool.Domain.Attempt;
using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.StudentCourseInformation;

namespace OnlineSchool.Domain.Student;

public class StudentEntity
{
    private List<StudentCourseInformationEntity> _informationAdmissions = new();
    private List<AttemptEntity> _attempts = new();
         
    public Guid Id { get; }

    public string LastName { get; }

    public string FirstName { get; }

    public string? Patronymic { get; }

    public DateTime BirthDay { get; }

    public IReadOnlyList<StudentCourseInformationEntity> InformationAdmissions => _informationAdmissions.AsReadOnly();
    public IReadOnlyCollection<AttemptEntity> Attempts => _attempts.AsReadOnly();

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

        _informationAdmissions.Add(new StudentCourseInformationEntity(this, course));

        return true;
    }

    public string GetFullName()
    {
        return Patronymic is null ? $"{LastName} {FirstName}": $"{LastName} {FirstName} {Patronymic}";
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        var student = obj as StudentEntity;
        return student.Id == Id;
    }
}