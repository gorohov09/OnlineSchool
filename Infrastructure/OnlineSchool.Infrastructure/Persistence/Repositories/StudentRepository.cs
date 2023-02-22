using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.InformationAdmission;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly OnlineSchoolDbContext _context;

    public StudentRepository(OnlineSchoolDbContext context)
    {
        _context = context;
    }

    public async Task AddStudent(StudentEntity student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task<List<InformationAdmissionEntity>> GetInformationAdmissions(Guid studentId)
    {
        var user = await _context.Students
            .Include(student => student.InformationAdmissions)
            .ThenInclude(inf => inf.Course)
            .FirstOrDefaultAsync(student => student.Id == studentId);

        return user?.InformationAdmissions.ToList();
    }
}