using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.Course;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.ToTable("Courses");

        builder.HasKey(course => course.Id);

        builder.Property(course => course.Name).IsRequired();
        builder.Property(course => course.Description);
        builder.Property(course => course.Created);
        builder.Property(course => course.Updated);
        builder.Property(course => course.CountTasks);
    }
}