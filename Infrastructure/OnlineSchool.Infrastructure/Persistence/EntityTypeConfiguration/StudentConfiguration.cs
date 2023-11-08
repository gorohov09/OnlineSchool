using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(student => student.Id);
        builder.Property(student => student.LastName);
        builder.Property(student => student.FirstName);
        builder.Property(student => student.Patronymic);
        builder.Property(student => student.BirthDay);
    }
}
