using OnlineSchool.Domain.InformationAdmission;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IStudentRepository
{
    void AddStudent(StudentEntity student);
    List<InformationAdmissionEntity> GetInformationAdmissions(Guid studentId);
}

