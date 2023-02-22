using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Course;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly OnlineSchoolDbContext _context;

    public CourseRepository(OnlineSchoolDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddCourse(CourseEntity course)
    {
        await _context.Courses.AddAsync(course);
        return await _context.SaveChangesAsync() > 0 ? true : false;
    }
}
