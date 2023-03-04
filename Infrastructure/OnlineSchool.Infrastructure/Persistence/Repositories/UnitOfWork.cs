using OnlineSchool.App.Common.Interfaces.Persistence;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public IStudentRepository Students { get; }

    public IModuleRepository Modules { get; }

    public ILessonRepository Lessons { get; }

    public ICourseRepository Courses { get; }

    public IUserRepository Users { get; }

    public UnitOfWork(ApplicationDbContext context, IStudentRepository studentRepository,
        IModuleRepository moduleRepository, ILessonRepository lessonRepository,
        ICourseRepository courseRepository, IUserRepository userRepository)
    {
        _context = context;
        Students = studentRepository;
        Modules = moduleRepository;
        Lessons = lessonRepository;
        Courses = courseRepository;
        Users = userRepository;
    }

    public async Task<bool> CompleteAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
