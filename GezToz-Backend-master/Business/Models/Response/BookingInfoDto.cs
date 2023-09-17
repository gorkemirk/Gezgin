using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class BookingInfoDto
    {

        public int Id { get; set; }
        public int HouseId { get; set; }
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public string Checkin { get; set; } = default!;
        public string CheckOut { get; set; } = default!;
        public int PaymentStatus { get; set; } = default!;
        public int BookingStatus { get; set; } = default!;
    }
}
