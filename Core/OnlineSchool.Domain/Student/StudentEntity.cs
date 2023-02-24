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

    public void EnrollCourse(CourseEntity course)
    {
        _informationAdmissions.Add(new InformationAdmissionEntity(this, course));
    }

    public string GetFullName()
    {
        return Patronymic is null ? $"{LastName} {FirstName}": $"{LastName} {FirstName} {Patronymic}";
    }
}