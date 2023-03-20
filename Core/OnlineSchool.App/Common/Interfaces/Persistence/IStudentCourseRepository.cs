using OnlineSchool.Domain.Student;
using OnlineSchool.Domain.StudentCourseInformation;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IStudentCourseRepository : IGenericRepository<StudentCourseInformationEntity>
{
    Task<StudentCourseInformationEntity?> FindStudentCourse(Guid courseId, Guid studentId);
    Task<List<StudentCourseInformationEntity>> GetRatingStudentCourseInformationsWithStudentByCourseId(Guid courseId);
}