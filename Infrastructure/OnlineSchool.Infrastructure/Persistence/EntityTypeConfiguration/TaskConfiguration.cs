using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Tasks");
        builder.HasKey(task => task.Id);
        builder.Property(task => task.Name);
        builder.Property(task => task.Order);
        builder.Property(task => task.Description);
        builder.Property(task => task.RightAnswer);
        builder.Property(task => task.TaskType);


        builder.HasOne(task => task.Lesson)
            .WithMany(lesson => lesson.Tasks)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
