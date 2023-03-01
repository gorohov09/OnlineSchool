using Microsoft.EntityFrameworkCore;
using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.Course.Entities;
using OnlineSchool.Domain.InformationAdmission;
using OnlineSchool.Domain.Student;
using OnlineSchool.Domain.StudentTaskInformation;
using OnlineSchool.Domain.User;
using OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

namespace OnlineSchool.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<InformationAdmissionEntity> InformationAdmissions { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ModuleEntity> Modules { get; set; }
    public DbSet<LessonEntity> Lessons { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<StudentTaskInformationEntity> StudentTaskInformation { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new StudentConfiguration());
        builder.ApplyConfiguration(new CourseConfiguration());
        builder.ApplyConfiguration(new InformationAdmissionConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new ModuleConfiguration());
        builder.ApplyConfiguration(new LessonConfiguration());
        builder.ApplyConfiguration(new TaskConfiguration());
        builder.ApplyConfiguration(new StudentTaskInformationConfiguration());

        base.OnModelCreating(builder);
    }
}