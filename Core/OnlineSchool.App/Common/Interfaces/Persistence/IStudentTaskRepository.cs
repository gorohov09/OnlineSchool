using OnlineSchool.Domain.StudentTaskInformation;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IStudentTaskRepository
{
    Task<List<StudentTaskInformationEntity>> GetTasksStudentForLesson(Guid studentId, IEnumerable<Guid> taskIds);
    Task<StudentTaskInformationEntity> GetTaskInformStudentWithTask(Guid studentId, Guid taskId);
}