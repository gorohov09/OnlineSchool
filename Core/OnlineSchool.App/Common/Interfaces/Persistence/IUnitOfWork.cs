namespace OnlineSchool.App.Common.Interfaces.Persistence;

public interface IUnitOfWork
{
    IStudentRepository Students { get; }
    IModuleRepository Modules { get; }
    ILessonRepository Lessons { get; }
    ICourseRepository Courses { get; }
    IUserRepository Users { get; }
    IStudentTaskRepository StudentTasks { get; }
    IStudentCourseRepository StudentCourses { get; }

    Task<bool> CompleteAsync();
}
