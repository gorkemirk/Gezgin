using Infrastructure.Data.Postgres.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Email).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.UserName).IsRequired();
        builder.HasIndex(x => x.UserName).IsUnique();
        builder.Property(x => x.FullName).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.PasswordSalt).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.IsDeleted).IsRequired();

        builder.HasMany(u => u.Booking)
          .WithOne(b => b.User)
          .HasForeignKey(b => b.UserId);

        builder.HasMany(u => u.Card)
         .WithOne(c => c.User)
         .HasForeignKey(b => b.UserId);

        builder.HasMany(u => u.Comment)
         .WithOne(c => c.User)
         .HasForeignKey(b => b.User_Id);
     
        builder.HasMany(u => u.House)
         .WithOne(c => c.User)
         .HasForeignKey(b => b.UserId);







    }
}