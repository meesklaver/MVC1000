using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1000.Models
{
    public class Order
    {
        
        [Key]
        public int OrderId { get; set; }
        //public Mvc1000User UserId { get; set; }
        public DateTime Date { get; set; }
        public Order()
        {
            Date = DateTime.Now;
        }
        public double Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime DeliverAt { get; set; }

    }
    public class ProductOrder
    {
        public Products ProductId { get; set; }
        public Order OrderId { get; set; }
    }
}
