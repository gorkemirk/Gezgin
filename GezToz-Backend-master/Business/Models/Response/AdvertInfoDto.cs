using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class AdvertInfoDto
    {
        public int UserId { get; set; }
        public DateTime AdvertDate { get; set; } = default!;
        public bool AdvertStatus { get; set; } = default!;
    }
}
