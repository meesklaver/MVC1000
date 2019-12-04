using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1000.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public double Price { get; set; }
        public long Ean { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string ImageFileName { get; set; }

        public string Height { get; set; }
        public string Weight { get; set; }
    }
}
