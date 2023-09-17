using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Postgres.Entities.Base;

namespace Infrastructure.Data.Postgres.Entities
{
    public class Card : Entity<int>
    {

        public int UserId { get; set; }
        
        public string CardHolderName { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public DateOnly ExpirationDate { get; set; } = default!;
        public int CardCvc { get; set; } = default!;
        public string CardType { get; set; } = default!;

        //public ICollection<User> Users { get; set; } = new List<User>();
        public User User { get; set; } 
    }
}
