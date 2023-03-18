using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
{
    public StudentRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<StudentEntity?> FindStudentByIdWithInformAdmissions(Guid studentId)
    {
        return await _context.Students
            .Include(student => student.InformationAdmissions)
            .ThenInclude(inf => inf.Course)
            .FirstOrDefaultAsync(student => student.Id == studentId);
    }

    public async Task<StudentEntity?> FindStudentByIdWithInformAdmissionsCourseByIdModulesLessonsTasks(Guid studentId, Guid courseId)
    {
        return await _context.Students
            .Include(student => student.InformationAdmissions.Where(inf => inf.Course.Id == courseId))
            .ThenInclude(inf => inf.Course)
            .ThenInclude(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .ThenInclude(lesson => lesson.Tasks)
            .FirstOrDefaultAsync(student => student.Id == studentId);
    }

    public async Task<StudentEntity?> FindStudentByIdWithInformAdmissionsCoursesModulesLessonsTasks(Guid studentId)
    {
        return await _context.Students
            .Include(student => student.InformationAdmissions)
            .ThenInclude(inf => inf.Course)
            .ThenInclude(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .ThenInclude(lesson => lesson.Tasks)
            .FirstOrDefaultAsync(student => student.Id == studentId);
    }

    public async Task<bool> IsExists(Guid studentId)
    {
        return await _context.Students.AnyAsync(student => student.Id == studentId);
    }
}