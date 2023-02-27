using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
{
    public void Configure(EntityTypeBuilder<LessonEntity> builder)
    {
        builder.ToTable("Lessons");
        builder.HasKey(lesson => lesson.Id);

        builder.Property(lesson => lesson.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(lesson => lesson.Name);
        builder.Property(lesson => lesson.Order);
        builder.Property(lesson => lesson.VideoEmbedCode);

        builder.HasOne(lesson => lesson.Module)
            .WithMany(module => module.Lessons)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
