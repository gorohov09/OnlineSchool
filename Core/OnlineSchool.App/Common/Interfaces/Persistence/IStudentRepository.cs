using OnlineSchool.Domain.InformationAdmission;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IStudentRepository
{
    Task AddStudent(StudentEntity student);
    Task<List<InformationAdmissionEntity>> GetInformationAdmissions(Guid studentId);
    Task<bool> IsExists(Guid studentId);
}

