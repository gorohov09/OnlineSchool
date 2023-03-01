using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class CourseRepository : GenericRepository<CourseEntity>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<CourseEntity?> FindCourseByIdWithModules(Guid id)
    {
        return await _context.Courses
            .Include(course => course.Modules)
            .FirstOrDefaultAsync(course => course.Id == id);
    }

    public async Task<CourseEntity?> FindCourseByIdWithModulesLessons(Guid id)
    {
        return await _context.Courses
            .Include(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .FirstOrDefaultAsync(course => course.Id == id);
    }

    public async Task<CourseEntity?> FindCourseByIdWithModulesLessonsTasks(Guid id)
    {
        return await _context.Courses
            .Include(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .ThenInclude(lesson => lesson.Tasks)
            .FirstOrDefaultAsync(course => course.Id == id);
    }

}
