using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.StudentCourseInformation;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class InformationAdmissionConfiguration : IEntityTypeConfiguration<StudentCourseInformationEntity>
{
    public void Configure(EntityTypeBuilder<StudentCourseInformationEntity> builder)
    {
        builder.ToTable("InformationAdmission");

        builder.HasKey(inf => inf.Id);
        builder.Property(inf => inf.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(inf => inf.CountCompletedTasks);
        builder.Property(inf => inf.DateAdmission);

        builder.HasOne(inf => inf.Student)
            .WithMany(student => student.InformationAdmissions)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(inf => inf.Course)
            .WithMany(course => course.InformationAdmissions)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
