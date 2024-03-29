﻿using Microsoft.EntityFrameworkCore;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.Domain.StudentCourseInformation;

namespace OnlineSchool.Infrastructure.Persistence.Repositories;

public class StudentCourseRepository : GenericRepository<StudentCourseInformationEntity>, IStudentCourseRepository
{
    public StudentCourseRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<StudentCourseInformationEntity?> FindStudentCourse(Guid courseId, Guid studentId)
    {
        return await _context.InformationAdmissions
            .FirstOrDefaultAsync(inf => inf.Course.Id == courseId && inf.Student.Id == studentId);
    }

    public async Task<List<StudentCourseInformationEntity>> GetRatingStudentCourseInformationsWithStudentByCourseId(Guid courseId)
    {
        return await _context.InformationAdmissions
            .Include(inf => inf.Student)
            .Where(inf => inf.Course.Id == courseId)
            .OrderByDescending(inf => inf.CountCompletedTasks)
            .ToListAsync();
    }
}