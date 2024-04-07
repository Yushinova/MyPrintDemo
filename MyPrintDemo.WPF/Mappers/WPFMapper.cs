using MyPrintDemo.BLL.Models;
using MyPrintDemo.Models;
using MyPrintDemo.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MyPrintDemo.WPF.Mappers
{
    public static class WPFMapper
    {
        public static Order_view MapOrder_BLLToOrder_view(Order_BLL order, IEnumerable<Image_BLL> images)
        {
            string pay= "";
            string status = "";
            if (order.IsPaid == 1) { pay = "Оплачен"; }
            else pay = "Не оплачен";
            if (order.IsReady == 1) { status = "Готов"; }
            if (order.IsProduction == 1) { status = "В производстве"; }
            else { status = "Предварительный"; }
            List<Image_BLL> test = new List<Image_BLL>();
            foreach (Image_BLL image in images)
            {
                if(image.order.Id_order==order.Id_order) { test.Add(image); }
            }
            return new Order_view()
            {
                Id = order.Id_order,
                Order_date = order.Date_order.ToString("dd-MM-yyyy H:mm"),
                Product_Name = order.product_bll.Name_product,
                Size = $"{order.product_bll.Width}x{order.product_bll.Height}мм",
                Cost = order.product_bll.Cost_product,
                IsPaid = pay,
                Product_count = order.product_bll.Count_product,
                Status = status,
                images = test
            };
        }
        public static Product_view MapProduct_BLLToProduct_view(Product_BLL product)
        {
            return new Product_view()
            {
                Id = product.Id_product,
                Name = $"{product.Name_product} {product.Count_product} шт"
            };
        }
    }
}
