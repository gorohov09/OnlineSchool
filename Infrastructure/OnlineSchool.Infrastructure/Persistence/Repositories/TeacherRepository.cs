using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Teacher;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class TeacherRepository : GenericRepository<TeacherEntity>, ITeacherRepository
{
    public TeacherRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<TeacherEntity> GetTeacherWithCoursesStnCrsInformationStudent(Guid teacherId)
    {
        return await _context.Teachers
            .Include(teacher => teacher.Courses)
            .ThenInclude(course => course.InformationAdmissions)
            .ThenInclude(inf => inf.Student)
            .FirstOrDefaultAsync(teacher => teacher.Id == teacherId);  
    }
}
