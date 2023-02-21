using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Infrastructure.Persistence;

public class StudentRepository : IStudentRepository
{
    public static readonly List<Student> _students = new();

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }
}