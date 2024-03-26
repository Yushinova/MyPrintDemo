using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.Models
{
    public class Payment
    {
        public int Id_payment { get; set; }
        public double Sum_payment { get; set; }
        public DateTime Date_payment { get; set; }
        public int Order_Id { get; set; }
    }
}
