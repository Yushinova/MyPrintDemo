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
        public DateTime Order_date { get; set; }
        public string Product_Name { get; set; }
        public string Size { get; set; }
        public double Cost { get; set; }
        public string IsPaid { get; set; }
        public int Product_count { get; set; }
        public string Status { get; set; }
        public List<BLL.Models.Image_BLL> images { get; set; }
        public Order_view(BLL.Models.Order_BLL order, List<BLL.Models.Image_BLL> list)
        {
            Id = order.Id_order;
            Order_date = order.Date_order;
            Product_Name = order.product_bll.Name_product;
            Size = $"{order.product_bll.Width}X{order.product_bll.Height}мм";
            Cost = order.product_bll.Cost_product;
            if (order.IsPaid == 1) { IsPaid = "Оплачено"; } 
            else { IsPaid = "Не оплачено"; }
            Product_count = order.product_bll.Count_product;
            if (order.IsReady == 1) { Status = "Готов"; }
            if (order.IsProduction==1) { Status = "В производстве"; }
            else { Status = "Предварительный"; }
            images = list;
        }
    }
}
