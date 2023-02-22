using OnlineSchool.Domain.Course;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface ICourseRepository
{
    Task<bool> AddCourse(CourseEntity course);
}