using Infrastructure.Data.Postgres.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    public class Advert : Entity<int>
    {
        public DateTime AdvertDate { get; set; } = default!;
        public bool AdvertStatus { get; set; } = default!;

        public User User { get; set; }
    }
}
