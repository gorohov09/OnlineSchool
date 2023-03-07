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
            .ThenInclude(student => student.Course)
            .FirstOrDefaultAsync(student => student.Id == studentId);
    }

    public async Task<bool> IsExists(Guid studentId)
    {
        return await _context.Students.AnyAsync(student => student.Id == studentId);
    }
}