using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
{
    public TaskRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<TaskEntity> GeFirstTaskWithAttemptsByLesson(Guid studentId, Guid lessonId)
    {
        return await _context.Tasks
            .Include(task => task.Attempts.Where(attempt => attempt.StudentId == studentId))
            .Where(task => task.Lesson.Id == lessonId)
            .OrderBy(task => task.Order)
            .FirstAsync();
    }

    public async Task<List<TaskEntity>> GetStudentLessonTasksWithAttempts(Guid studentId, Guid lessonId)
    {
        return await _context.Tasks
            .Include(task => task.Attempts.Where(attempt => attempt.StudentId == studentId))
            .Where(task => task.Lesson.Id == lessonId)
            .OrderBy(task => task.Order)
            .ToListAsync();
    }

    public async Task<TaskEntity> GetStudentTaskWithAttempts(Guid studentId, Guid taskId)
    {
        return await _context.Tasks
            .Include(task => task.Attempts.Where(attempt => attempt.StudentId == studentId))
            .FirstOrDefaultAsync(task => task.Id == taskId);
    }
}
