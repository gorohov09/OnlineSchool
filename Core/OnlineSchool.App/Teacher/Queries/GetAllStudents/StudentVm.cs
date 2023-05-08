using OnlineSchool.Domain.Student;

namespace OnlineSchool.App.Teacher.Queries.GetAllStudents;

public class StudentVm
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? Patronymic { get; set; }
    public DateTime? BirthDay { get; set; }
    public List<string> CoursesName { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        var student = obj as StudentVm;
        return student.Id == Id;
    }
}
