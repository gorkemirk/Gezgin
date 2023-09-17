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
   

    public class BookingConfiguration : BaseConfiguration<Booking, int>
    {
        public override void Configure(EntityTypeBuilder<Booking> builder)
        {
           

            base.Configure(builder);
            builder.Property(b => b.Checkin).IsRequired();
            builder.Property(b => b.CheckOut).IsRequired();
            builder.Property(b => b.PaymentStatus).IsRequired();
            builder.Property(b => b.BookingStatus).IsRequired();

            builder.HasOne(b => b.House)
             .WithMany(h => h.Booking)
             .HasForeignKey(b => b.HouseId);

            builder.HasOne(b => b.User)
                .WithMany(u => u.Booking)
                .HasForeignKey(b => b.UserId);

        }
    }
}

