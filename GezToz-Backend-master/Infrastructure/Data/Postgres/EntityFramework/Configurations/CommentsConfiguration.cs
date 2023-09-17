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
    public class CommentsConfiguration : BaseConfiguration<Comment, int>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.CommentHeader)
                .IsRequired();

            builder.Property(c => c.CommentText)
                .IsRequired();
            


            builder.Property(c => c.StarRating)
                .IsRequired();



            builder.HasOne(x => x.House)
                .WithMany(c => c.Comment)
                .HasForeignKey(x => x.House_Id)
                .IsRequired();



            builder.HasOne(x => x.User)
            .WithMany(u => u.Comment)
            .HasForeignKey(x => x.User_Id)
            .IsRequired();
            


        }
    }

}

