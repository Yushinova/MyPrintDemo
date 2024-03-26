using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.Models
{
    public class Order
    {
        public int Id_order { get; set; }
        public double? Cost_order { get; set; }
        public DateTime Date_order { get; set; }
        public bool IsPaid {  get; set; }
        public bool IsProduction { get; set; }
        public bool IsReady { get; set; }
        public int User_ID { get; set; }
    }
}
