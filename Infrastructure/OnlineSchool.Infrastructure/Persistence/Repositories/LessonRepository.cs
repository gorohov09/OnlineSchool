using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class LessonRepository : GenericRepository<LessonEntity>, ILessonRepository
{
    public LessonRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<LessonEntity?> FindFirstLessonByCourse(Guid courseId)
    {
        return await _context.Lessons
            .Where(lesson => lesson.Module.Course.Id == courseId)
            .OrderBy(lesson => lesson.Order)
            .FirstOrDefaultAsync();   
    }

    public async Task<LessonEntity?> FindLessonByIdWithTasks(Guid lessonId)
    {
        return await _context.Lessons
            .Include(lesson => lesson.Tasks.OrderBy(task => task.Order))
            .FirstOrDefaultAsync(lesson => lesson.Id == lessonId);
    }
}