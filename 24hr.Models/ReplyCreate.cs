using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Models
{
    public class ReplyCreate
    {
        
        public string Text { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        //public int CommentId { get; set; }
    }
}
