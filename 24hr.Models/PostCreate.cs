using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24hr.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a Name with at least 3 Characters.")]
        [MaxLength(75, ErrorMessage = "Please keep the Name under 75 Characters.")]
        public string Title { get; set; }
        [MaxLength(3000)]
        public string Text { get; set; }
    }
}
