using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.Models
{
    public class Product
    {
        public int Id_product { get; set; }
        public string Name_product { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Count_product { get; set; }
        public double? Cost_product { get; set; }
        public bool IsActuality { get; set; }

    }
}
