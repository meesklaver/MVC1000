using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1000.Models
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }
        public int DiscountPrice { get; set; }
        public Date ValidUntil { get; set; }
        public Image Image { get; set; }
    }

    public class Productsale
    {
        public Products ProductId { get; set; }
        public Sales SalesId { get; set; }
    }
}
