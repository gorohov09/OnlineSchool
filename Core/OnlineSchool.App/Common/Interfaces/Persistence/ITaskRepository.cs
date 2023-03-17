using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface ITaskRepository : IGenericRepository<TaskEntity>
{
    Task<List<TaskEntity>> GetStudentLessonTasksWithAttempts(Guid studentId, Guid lessonId);
    Task<TaskEntity> GetStudentTaskWithAttempts(Guid studentId, Guid taskId);
    Task<TaskEntity> GeFirstTaskWithAttemptsByLesson(Guid studentId, Guid lessonId);
}
