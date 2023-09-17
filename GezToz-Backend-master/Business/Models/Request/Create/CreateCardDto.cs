using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Create
{
    public class CreateCardDto
    {
        public int UserId { get; set; }
       
        public string CardHolderName { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public DateOnly ExpirationDate { get; set; } = default!;
        public int CardCvc { get; set; } = default!;
        public string CardType { get; set; } = default!;
    }
}
