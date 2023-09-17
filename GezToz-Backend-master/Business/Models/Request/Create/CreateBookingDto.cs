using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Create
{
    public class CreateBookingDto
    {

        public string Checkin { get; set; } = default!;
        public string CheckOut { get; set; } = default!;
        public int HouseId { get; set; }
        public int UserId { get; set; }
        public int PaymentStatus { get; set; } = default!;
        public int BookingStatus { get; set; } = default!;
    }
}
