using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly OnlineSchoolDbContext _context;

    public CourseRepository(OnlineSchoolDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddCourse(CourseEntity course)
    {
        await _context.Courses.AddAsync(course);
        return await _context.SaveChangesAsync() > 0 ? true : false;
    }

    public async Task<CourseEntity?> FindCourseById(Guid courseId)
    {
        return await _context.Courses
            .Include(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .ThenInclude(lesson => lesson.Tasks)
            .FirstOrDefaultAsync(course => course.Id == courseId);
    }

    public async Task<LessonEntity?> FindLessonById(Guid lessonId)
    {
        return await _context.Lessons
            .Include(lesson => lesson.Tasks)
            .FirstOrDefaultAsync(lesson => lesson.Id == lessonId);
    }

    public Task<LessonEntity?> FindLessonByIdWithTasks(Guid lessonId)
    {
        throw new NotImplementedException();
    }

    public async Task<ModuleEntity?> FindModuleById(Guid moduleId)
    {
        return await _context.Modules
            .Include(module => module.Lessons)
            .FirstOrDefaultAsync(module => module.Id == moduleId);
    }

    public async Task<bool> UpdateCourse(CourseEntity course)
    {
        _context.Courses.Update(course);
        return await _context.SaveChangesAsync() > 0 ? true : false;
    }

    public async Task<bool> UpdateLesson(LessonEntity lesson)
    {
        _context.Lessons.Update(lesson);
        return await _context.SaveChangesAsync() > 0 ? true : false;
    }

    public async Task<bool> UpdateModule(ModuleEntity module)
    {
        _context.Modules.Update(module);
        return await _context.SaveChangesAsync() > 0 ? true : false;
    }
}
