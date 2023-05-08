using OnlineSchool.Domain.Teacher;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface ITeacherRepository : IGenericRepository<TeacherEntity>
{
    Task<TeacherEntity> GetTeacherWithCoursesStnCrsInformationStudent(Guid teacherId);
}
