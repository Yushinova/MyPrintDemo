using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.Models
{
    public record Image_product
    {
        public int Id_image { get; set; }
        public string Url { get; set; }
        public int Order_ID { get; set; }
    }
}
