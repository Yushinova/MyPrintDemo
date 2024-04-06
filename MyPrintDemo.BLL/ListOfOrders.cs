using MyPrintDemo.BLL.Models;
using MyPrintDemo.Models;
using MyPrintDemo.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.BLL
{
    public class ListOfOrders
    {
        private ICrud<Order> order_source;
        
        public ListOfOrders()
        {
            order_source = new TableOrders();
        }
        public IEnumerable<Order_BLL> GetAll()
        {
            List<Order_BLL> orders = new List<Order_BLL>();
            var result = order_source.GetAll();
            TableUsers users = new TableUsers();
            TableProducts products = new TableProducts();

            var all_users = users.GetAll();
            var all_products = products.GetAll();
            foreach (var item in result)
            {
               orders.Add(Mappers.BLLMapper.MapOrderToOrder_BLL(item, all_users, all_products));
            }
            return orders;
        }

        //public async Task<Order_BLL> GetByIDAsync(int id) { };

        public void InsertObj(Order_BLL order)//делаем запрос на вставку и передаем в сервис
        {

            order_source.InsertObj(Mappers.BLLMapper.MapOrder_BLLToOrder(order));
        }

        public void UpdateObj(Order_BLL order)//тоже самое
        {

            order_source.UpdateObj(Mappers.BLLMapper.MapOrder_BLLToOrder(order));
        }
    }
}
