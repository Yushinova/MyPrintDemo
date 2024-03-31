using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.BLL.Models
{
    public record Image_BLL
    {
        public int Id_image { get; set; }
        public string Url { get; set; }
        public Order_BLL order { get; set; }
    }
}
