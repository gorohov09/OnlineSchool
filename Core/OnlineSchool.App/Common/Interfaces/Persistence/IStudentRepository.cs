using OnlineSchool.Domain.InformationAdmission;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IStudentRepository : IGenericRepository<StudentEntity>
{
    Task AddStudent(StudentEntity student);
    Task<List<InformationAdmissionEntity>> GetInformationAdmissions(Guid studentId);
    Task<bool> IsExists(Guid studentId);
    Task<StudentEntity?> FindStudentById(Guid studentId);
    Task<bool> UpdateStudent(StudentEntity student);
}

