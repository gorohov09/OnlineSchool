using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface ICourseRepository
{
    Task<bool> AddCourse(CourseEntity course);
    Task<CourseEntity?> FindCourseById(Guid courseId);
    Task<bool> UpdateCourse(CourseEntity course);
}