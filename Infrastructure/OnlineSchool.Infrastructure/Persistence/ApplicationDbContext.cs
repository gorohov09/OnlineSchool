using Microsoft.EntityFrameworkCore;
using OnlineSchool.Domain.Attempt;
using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.Course.Entities;
using OnlineSchool.Domain.Student;
using OnlineSchool.Domain.StudentCourseInformation;
using OnlineSchool.Domain.User;
using OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

namespace OnlineSchool.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<StudentCourseInformationEntity> InformationAdmissions { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ModuleEntity> Modules { get; set; }
    public DbSet<LessonEntity> Lessons { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<AttemptEntity> Attempts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new StudentConfiguration());
        builder.ApplyConfiguration(new CourseConfiguration());
        builder.ApplyConfiguration(new StudentCourseInformationConfiguration());
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new ModuleConfiguration());
        builder.ApplyConfiguration(new LessonConfiguration());
        builder.ApplyConfiguration(new TaskConfiguration());
        builder.ApplyConfiguration(new AttemptConfiguration());

        base.OnModelCreating(builder);
    }
}