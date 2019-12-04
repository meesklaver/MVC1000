using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1000.Models
{
    public class NewsMessage
    {
        [Key]
        public int NewsId { get; set; }
       // public Mvc1000User UserId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public Image Image { get; set; }
    }
}
