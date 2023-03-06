using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
{
    public TaskRepository(ApplicationDbContext context) : base(context)
    {
    }

    public Task<List<TaskEntity>> GetStudentLessonTasksWithAttempts(Guid studentId, Guid lessonId)
    {
        throw new NotImplementedException();
    }

    public Task<TaskEntity> GetStudentTaskWithAttempts(Guid studentId, Guid taskId)
    {
        throw new NotImplementedException();
    }
}
