using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Infrastructure.Persistence;

public class StudentRepository : IStudentRepository
{
    public static readonly List<StudentEntity> _students = new();

    public void AddStudent(StudentEntity student)
    {
        _students.Add(student);
    }
}