using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSchool.Domain.User;

namespace OnlineSchool.Infrastructure.Persistence.EntityTypeConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(user => user.Id);
        builder.Property(user => user.FirstName);
        builder.Property(user => user.LastName);
        builder.Property(user => user.Password);
        builder.Property(user => user.Email);
    }
}