using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.StudentTaskInformation;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class StudentTaskRepository : IStudentTaskRepository
{
    private readonly ApplicationDbContext _context;

    public StudentTaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<StudentTaskInformationEntity> GetTaskInformStudentWithTask(Guid studentId, Guid taskId)
    {
        return await _context.StudentTaskInformation
            .Include(studentTaskInform => studentTaskInform.Attempts)
            .Include(studentTaskInform => studentTaskInform.Task)
            .Where(studentTaskInform => studentTaskInform.StudentId == studentId &&
            studentTaskInform.TaskId == taskId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<StudentTaskInformationEntity>> GetTasksStudentForLesson(
        Guid studentId, 
        IEnumerable<Guid> taskIds)
    {
        return await _context.StudentTaskInformation
            .Include(studentTask => studentTask.Task)
            .Where(studentTask => studentTask.StudentId == studentId &&
            taskIds.Contains(studentTask.TaskId))
            .OrderBy(studentTask => studentTask.Task.Order)
            .ToListAsync();
    }
}