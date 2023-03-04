using OnlineSchool.Domain.InformationAdmission;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IStudentCourseRepository : IGenericRepository<InformationAdmissionEntity>
{
    Task<InformationAdmissionEntity?> FindStudentCourse(Guid courseId, Guid studentId);
}