using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.InformationAdmission;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Infrastructure.Persistence;

public class StudentRepository : IStudentRepository
{
    public static readonly List<StudentEntity> _students = new();

    public void AddStudent(StudentEntity student)
    {
        _students.Add(student);
    }

    public List<InformationAdmissionEntity> GetInformationAdmissions(Guid studentId)
    {
        return _students
            .FirstOrDefault(student => student.Id == studentId).InformationAdmissions.ToList();
    }
}