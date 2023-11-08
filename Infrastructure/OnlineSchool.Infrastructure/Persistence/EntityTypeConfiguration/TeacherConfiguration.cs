using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.Teacher;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class TeacherConfiguration : IEntityTypeConfiguration<TeacherEntity>
{
    public void Configure(EntityTypeBuilder<TeacherEntity> builder)
    {
        builder.ToTable("Teachers");
        builder.HasKey(teacher => teacher.Id);
        builder.Property(teacher => teacher.LastName);
        builder.Property(teacher => teacher.FirstName);
        builder.Property(teacher => teacher.Patronymic);
        builder.Property(teacher => teacher.BirthDay);
    }
}


