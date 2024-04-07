using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.WPF.ViewModels
{
    public class Order_view
    {
        public int Id { get; set; }
        public string Order_date { get; set; }
        public string Product_Name { get; set; }
        public string Size { get; set; }
        public double Cost { get; set; }
        public string IsPaid { get; set; }
        public int Product_count { get; set; }
        public string Status { get; set; }
        public List<BLL.Models.Image_BLL> images { get; set; }
    }
}
