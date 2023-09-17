using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Postgres.Entities.Base;

namespace Infrastructure.Data.Postgres.Entities
{
    public class Comment : Entity<int>
    {
        public string CommentHeader { get; set; } = default!;

        public int User_Id { get; set; } = default!;
        public int House_Id { get; set; } = default!;
        public string CommentText { get; set; } = default!;
        public int StarRating { get; set; } = default!;

        public House House { get; set; }
        public User User { get; set; }
    }
}
