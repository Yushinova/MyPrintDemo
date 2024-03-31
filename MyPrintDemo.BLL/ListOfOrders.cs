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
        public List<Order_BLL> orders { get; }
        public ListOfOrders()
        {
            order_source = new TableOrders();
        }
        public async Task<IEnumerable<Order_BLL>> GetAllAsync()
        {
            var result = await order_source.GetAllAsync();
            TableUsers users = new TableUsers();
            TableProducts products = new TableProducts();

            var all_users =await users.GetAllAsync();
            var all_products =await products.GetAllAsync();
            foreach (var item in result)
            {
               orders.Add(Mappers.BLLMapper.MapOrderToOrder_BLL(item, all_users, all_products));
            }
            return orders;
        }

        //public async Task<Order_BLL> GetByIDAsync(int id) { };

        public async Task InsertObjAsync(Order_BLL order)//делаем запрос на вставку и передаем в сервис
        {

            await order_source.InsertObjAsync(Mappers.BLLMapper.MapOrder_BLLToOrder(order));
        }

        public async Task UpdateObjAsync(Order_BLL order)//тоже самое
        {

            await order_source.UpdateObjAsync(Mappers.BLLMapper.MapOrder_BLLToOrder(order));
        }
    }
}
