using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.PostgreSql
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.UserName).HasColumnName("user_name").IsRequired();
            builder.Property(p => p.FirstName).HasColumnName("first_name").IsRequired();
            builder.Property(p => p.LastName).HasColumnName("last_name").IsRequired();
            builder.Property(p => p.Email).HasColumnName("email").IsRequired();
            builder.Property(p => p.Phone).HasColumnName("phone").IsRequired();

            builder.HasIndex(p => p.UserName).IsUnique();
        }
    }
}
