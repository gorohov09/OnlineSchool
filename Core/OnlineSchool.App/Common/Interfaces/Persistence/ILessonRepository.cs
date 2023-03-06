using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface ILessonRepository : IGenericRepository<LessonEntity>
{
    Task<LessonEntity?> FindLessonByIdWithTasks(Guid lessonId);
}