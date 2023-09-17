using Infrastructure.Data.Postgres.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.Entities
{
    public class House : Entity<int>
    {
        public int UserId { get; set; }
        public string HouseName { get; set; } = default!;
        public string HouseDescription { get; set; } = default!;
        public string HouseAddres { get; set; } = default!;
        public string City { get; set; } = default!;
        public string Country { get; set; } = default!;
        // ZipCode Eklendi
        public int ZipCode { get; set; } = default!;
        // HouseImg Eklendi
        public string HouseImg { get; set; } = default!;
        public string RoomCount { get; set; } = default!;
        public string HousePrice { get; set; } = default!;
        public string Popularity { get; set; } = default!;


        public ICollection<Comment> Comment { get; set; } 

        //public Booking Bookings { get; set; }
        public ICollection<Booking> Booking { get; set; } 

        public User User { get; set; } = default!;
        

    }
}
