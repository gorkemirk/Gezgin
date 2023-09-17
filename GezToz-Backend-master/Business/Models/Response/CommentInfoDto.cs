using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.Response
{
    public class CommentInfoDto
    {

        public int Id { get; set; }
        public string CommentHeader { get; set; } = default!;

        public int User_Id { get; set; }
        public int House_Id { get; set; }
        public string CommentText { get; set; } = default!;
        public int StarRating { get; set; } = default!;
    }
}
