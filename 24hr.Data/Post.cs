using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        // public virtual Comment Comment { get; set; }
        [Required]
        public DateTimeOffset CreatedPost { get; set; }
        public DateTimeOffset? ModifiedPost { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public string Comment { get; set; }
    }
}
