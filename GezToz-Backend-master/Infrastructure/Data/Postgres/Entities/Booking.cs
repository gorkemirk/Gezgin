using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Postgres.Entities.Base;

namespace Infrastructure.Data.Postgres.Entities
{
    public class Booking : Entity<int>
    {
        public string Checkin { get; set; } = default!;
        public string CheckOut { get; set; } = default!;
        public int HouseId { get; set; } = default!;
        public int UserId { get; set; } = default!;
        public int PaymentStatus { get; set; } = default!;
        public int BookingStatus { get; set; } = default!;

        public House House { get; set; } 
        public User User { get; set; } 

    }
}
