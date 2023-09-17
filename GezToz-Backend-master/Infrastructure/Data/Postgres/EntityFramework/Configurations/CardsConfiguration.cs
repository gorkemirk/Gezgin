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
    public class CardsConfiguration : BaseConfiguration<Card , int>
    {
        public override void Configure(EntityTypeBuilder<Card> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.CardHolderName)
                .IsRequired();

            builder.Property(c => c.CardNumber)
                .IsRequired();

            builder.Property(c => c.ExpirationDate)
                .IsRequired();

            builder.Property(c => c.CardCvc)
                .IsRequired();

            builder.Property(c => c.CardType)
                .IsRequired();



            builder.HasOne(x => x.User)
            .WithMany(u => u.Card)
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}





