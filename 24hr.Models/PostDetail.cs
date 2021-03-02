using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Models
{
    public class PostDetail
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedPost { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedPost { get; set; }
        public string Comment { get; set; }
    }
}
