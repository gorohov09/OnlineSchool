using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.InformationAdmission;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class InformationAdmissionConfiguration : IEntityTypeConfiguration<InformationAdmissionEntity>
{
    public void Configure(EntityTypeBuilder<InformationAdmissionEntity> builder)
    {
        builder.ToTable("InformationAdmission");

        builder.HasKey(inf => inf.Id);

        builder.HasOne(inf => inf.Student)
            .WithMany(student => student.InformationAdmissions)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(inf => inf.Course)
            .WithMany(course => course.InformationAdmissions)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
