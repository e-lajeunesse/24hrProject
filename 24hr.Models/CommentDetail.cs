using _24hr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Models
{
    public class CommentDetail
    {
        public int Id { get; set; }

        [MaxLength(500, ErrorMessage = "You have too much to say; Please limit to 500 characters.")]
        public string Text { get; set; }

        public Guid Author { get; set; }


        public virtual List<string> Reply { get; set; } = new List<string>();

        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
