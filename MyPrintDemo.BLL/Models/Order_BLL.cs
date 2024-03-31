using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.BLL.Models
{
    public record Order_BLL
    {
        public int Id_order { get; set; }
        public DateTime Date_order { get; set; }
        public int IsPaid { get; set; }
        public int IsProduction { get; set; }
        public int IsReady { get; set; }
        public User_BLL user_bll { get; set; }
        public Product_BLL product_bll { get; set; }
    }
}
