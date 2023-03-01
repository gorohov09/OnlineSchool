using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.InformationAdmission;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddStudent(StudentEntity student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task<StudentEntity?> FindStudentById(Guid studentId)
    {
        return await _context.Students
            .Include(student => student.InformationAdmissions)
            .ThenInclude(inf => inf.Course)
            .FirstOrDefaultAsync(student => student.Id == studentId);
    }

    public async Task<List<InformationAdmissionEntity>> GetInformationAdmissions(Guid studentId)
    {
        var user = await _context.Students
            .Include(student => student.InformationAdmissions)
            .ThenInclude(inf => inf.Course)
            .ThenInclude(course => course.Modules)
            .ThenInclude(module => module.Lessons)
            .ThenInclude(lesson => lesson.Tasks)
            .FirstOrDefaultAsync(student => student.Id == studentId);

        return user?.InformationAdmissions.ToList();
    }

    public async Task<bool> IsExists(Guid studentId)
    {
        return await _context.Students.AnyAsync(student => student.Id == studentId);
    }

    public async Task<bool> UpdateStudent(StudentEntity student)
    {
        _context.Students.Update(student);
        return await _context.SaveChangesAsync() > 0 ? true : false;
    }
}