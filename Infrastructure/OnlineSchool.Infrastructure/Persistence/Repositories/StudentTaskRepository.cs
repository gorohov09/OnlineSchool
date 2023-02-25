using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.StudentTaskInformation;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class StudentTaskRepository : IStudentTaskRepository
{
    private readonly OnlineSchoolDbContext _context;

    public StudentTaskRepository(OnlineSchoolDbContext context)
    {
        _context = context;
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