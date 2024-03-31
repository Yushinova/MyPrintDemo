using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.BLL.Models
{
    public record Payment_BLL
    {
        public int Id_payment { get; set; }
        public double Sum_payment { get; set; }
        public DateTime Date_payment { get; set; }
        public Order_BLL order { get; set; }
    }
}
