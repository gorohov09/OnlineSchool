using OnlineSchool.Domain.StudentCourseInformation;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IStudentCourseRepository : IGenericRepository<StudentCourseInformationEntity>
{
    Task<StudentCourseInformationEntity?> FindStudentCourse(Guid courseId, Guid studentId);
}