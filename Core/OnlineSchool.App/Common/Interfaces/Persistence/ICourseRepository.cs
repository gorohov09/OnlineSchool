using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface ICourseRepository
{
    Task<bool> AddCourse(CourseEntity course);
    Task<CourseEntity?> FindCourseById(Guid courseId);
    Task<bool> UpdateCourse(CourseEntity course);
    Task<ModuleEntity?> FindModuleById(Guid moduleId);
    Task<bool> UpdateModule(ModuleEntity module);
    Task<LessonEntity?> FindLessonById(Guid lessonId);
    Task<LessonEntity?> FindLessonByIdWithTasks(Guid lessonId);
    Task<bool> UpdateLesson(LessonEntity lesson);

}