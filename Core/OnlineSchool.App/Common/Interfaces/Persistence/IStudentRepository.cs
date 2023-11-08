using OnlineSchool.Domain.Student;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IStudentRepository : IGenericRepository<StudentEntity>
{
    Task<bool> IsExists(Guid studentId);
    Task<StudentEntity?> FindStudentByIdWithInformAdmissions(Guid studentId);
    Task<StudentEntity?> FindStudentByIdWithInformAdmissionsCoursesModulesLessonsTasks(Guid studentId);
    Task<StudentEntity?> FindStudentByIdWithInformAdmissionsCourseByIdModulesLessonsTasks(Guid studentId, Guid courseId);
}

