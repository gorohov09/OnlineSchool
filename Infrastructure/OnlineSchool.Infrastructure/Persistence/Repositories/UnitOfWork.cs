﻿using OnlineSchool.App.Common.Interfaces.Persistence;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;

    public IStudentRepository Students { get; }

    public IModuleRepository Modules { get; }

    public ILessonRepository Lessons { get; }

    public ICourseRepository Courses { get; }

    public IUserRepository Users { get; }

    public ITaskRepository Tasks { get; }

    public IStudentCourseRepository StudentCourses { get; }

    public ITeacherRepository Teachers { get; }

    public UnitOfWork(ApplicationDbContext context, IStudentRepository studentRepository,
        IModuleRepository moduleRepository, ILessonRepository lessonRepository,
        ICourseRepository courseRepository, IUserRepository userRepository, 
        ITaskRepository taskRepository, IStudentCourseRepository studentCourseRepository,
        ITeacherRepository teacherRepository)
    {
        _context = context;
        Students = studentRepository;
        Modules = moduleRepository;
        Lessons = lessonRepository;
        Courses = courseRepository;
        Users = userRepository;
        Tasks = taskRepository;
        StudentCourses = studentCourseRepository;
        Teachers = teacherRepository;
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
