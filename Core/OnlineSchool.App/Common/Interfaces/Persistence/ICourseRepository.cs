using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface ICourseRepository : IGenericRepository<CourseEntity>
{
    Task<CourseEntity?> FindCourseByIdWithModulesLessonsTasks(Guid id);
    Task<CourseEntity?> FindCourseByIdWithModulesLessons(Guid id);
    Task<CourseEntity?> FindCourseByIdWithModules(Guid id);
}