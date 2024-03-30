using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.Models
{
    public record Order
    {
        public int Id_order { get; set; }
        public DateTime Date_order { get; set; }
        public int IsPaid {  get; set; }
        public int IsProduction { get; set; }
        public int IsReady { get; set; }
        public int User_ID { get; set; }
        public int Product_ID { get; set; }
    }
}
