using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.StudentTaskInformation;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class StudentTaskInformationConfiguration : IEntityTypeConfiguration<StudentTaskInformationEntity>
{
    public void Configure(EntityTypeBuilder<StudentTaskInformationEntity> builder)
    {
        builder.ToTable("StudentTaskInformation");

        builder.HasKey(inf => inf.Id);
        builder.Property(inf => inf.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(inf => inf.CountAttempts);
        builder.Property(inf => inf.IsSolve);
        builder.Property(inf => inf.TimeLastAttempt);

        builder.HasOne(inf => inf.Student)
            .WithMany(student => student.Tasks)
            .HasForeignKey(inf => inf.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(inf => inf.Task)
            .WithMany(task => task.Students)
            .HasForeignKey(inf => inf.TaskId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
