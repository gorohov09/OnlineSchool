using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.Course.Entities;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class ModuleConfiguration : IEntityTypeConfiguration<ModuleEntity>
{
    public void Configure(EntityTypeBuilder<ModuleEntity> builder)
    {
        builder.ToTable("Modules");
        builder.HasKey(module => module.Id);

        builder.Property(module => module.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.Property(module => module.Name);
        builder.Property(module => module.Order);


        builder.HasOne(module => module.Course)
            .WithMany(course => course.Modules)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
