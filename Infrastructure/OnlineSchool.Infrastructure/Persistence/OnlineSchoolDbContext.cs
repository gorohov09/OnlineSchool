using Microsoft.EntityFrameworkCore;
using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.InformationAdmission;
using OnlineSchool.Domain.Student;
using OnlineSchool.Domain.User;
using OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

namespace OnlineSchool.Infrastructure.Persistence;

public class OnlineSchoolDbContext : DbContext
{
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<InformationAdmissionEntity> InformationAdmissions { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    public OnlineSchoolDbContext(DbContextOptions<OnlineSchoolDbContext> options)
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

        base.OnModelCreating(builder);
    }
}