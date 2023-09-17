using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Request.Update
{
    public class AdvertUpdateDTO
    {
        public DateTime AdvertDate { get; set; } = default!;
        public bool AdvertStatus { get; set; } = default!;
    }
}
