using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Entities.Base;
using Infrastructure.Data.Postgres.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    public class HousesConfiguration : BaseConfiguration<House, int>
    {
        public override void Configure(EntityTypeBuilder<House> builder)
        {

            base.Configure(builder);


            builder.Property(h => h.HouseName).IsRequired();
            builder.Property(h => h.HouseDescription).IsRequired();
            builder.Property(h => h.HouseAddres).IsRequired();
            builder.Property(h => h.City).IsRequired();
            builder.Property(h => h.Country).IsRequired();
            builder.Property(h => h.ZipCode).IsRequired();
            builder.Property(h => h.HouseImg).IsRequired();
            builder.Property(h => h.RoomCount).IsRequired();
            builder.Property(h => h.HousePrice).IsRequired();
            builder.Property(h => h.Popularity).IsRequired();

            builder.HasMany(h => h.Comment)
            .WithOne(c => c.House)
            .HasForeignKey(c => c.House_Id);

            builder.HasMany(h => h.Booking)
                .WithOne(b => b.House)
                .HasForeignKey(b => b.HouseId);
     
            builder.HasOne(h => h.User)
                .WithMany(b => b.House)
                .HasForeignKey(b => b.UserId);
        }
    }
}


