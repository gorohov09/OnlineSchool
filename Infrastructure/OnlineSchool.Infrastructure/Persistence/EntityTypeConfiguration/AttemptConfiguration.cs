using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.StudentTaskInformation.Entities;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class AttemptConfiguration : IEntityTypeConfiguration<AttemptEntity>
{
    public void Configure(EntityTypeBuilder<AttemptEntity> builder)
    {
        builder.ToTable("Attempts");

        builder.HasKey(attempt => attempt.Id);
        builder.Property(attempt => attempt.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder.HasOne(attempt => attempt.StudentTaskInformation)
            .WithMany(inf => inf.Attempts)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(attempt => attempt.Answer).IsRequired();
        builder.Property(attempt => attempt.DateDispatch).IsRequired();
        builder.Property(attempt => attempt.IsRight).IsRequired();
    }
}
