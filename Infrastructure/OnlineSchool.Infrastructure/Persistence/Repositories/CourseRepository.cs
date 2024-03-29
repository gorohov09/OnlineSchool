﻿using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class CourseRepository : GenericRepository<CourseEntity>, ICourseRepository
{
    public CourseRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<CourseEntity?> FindCourseByIdWithModules(Guid id)
    {
        return await _context.Courses
            .Include(course => course.Modules)
            .FirstOrDefaultAsync(course => course.Id == id);
    }

    public async Task<CourseEntity?> FindCourseByIdWithModulesLessons(Guid id)
    {
        return await _context.Courses
            .Include(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .FirstOrDefaultAsync(course => course.Id == id);
    }

    public async Task<CourseEntity?> FindCourseByIdWithModulesLessonsTasks(Guid id)
    {
        return await _context.Courses
            .Include(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .ThenInclude(lesson => lesson.Tasks)
            .FirstOrDefaultAsync(course => course.Id == id);
    }

	public async Task<List<CourseEntity>?> FindCoursesByIdTeacherWithModulesLessonsTasksStudents(Guid id)
    {
        return await _context.Courses
            .Include(course => course.InformationAdmissions)
            .Include(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .ThenInclude(lesson => lesson.Tasks)
            .Where(course => course.Teacher.Id == id)
            .ToListAsync();
	}

    /// <summary>
    /// Пока что никаких популярных курсов не выбираем, пока это фиктивность
    /// В будущем здесь будет популярность по рейтингу курса
    /// </summary>
    /// <returns></returns>
    public async Task<List<CourseEntity>> FindPopularCoursesWithModulesLessonsTasksStudents()
    {
        return await _context.Courses
            .Include(course => course.InformationAdmissions)
            .ThenInclude(inf => inf.Student)
            .Include(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .ThenInclude(lesson => lesson.Tasks)
            .ToListAsync();
    }

    public async Task<CourseEntity?> GetCourseByTaskId(Guid taskId)
    {
        return await _context.Courses
            .FirstOrDefaultAsync(course =>
            course.Modules
            .SelectMany(module => module.Lessons)
            .SelectMany(lesson => lesson.Tasks)
            .Any(task => task.Id == taskId));
    }
}
