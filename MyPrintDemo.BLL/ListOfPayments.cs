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
    public class ListOfPayments
    {
        private ICrud<Payment> payment_source;
        public List<Payment_BLL> payments { get; }
        public ListOfPayments()
        {
            payment_source = new TablePayments();
        }
        public async Task<IEnumerable<Payment_BLL>> GetAllAsync()
        {
            var result = await payment_source.GetAllAsync();
            TableOrders orders = new TableOrders();
            TableUsers users = new TableUsers();
            TableProducts products = new TableProducts();

            var all_users = await users.GetAllAsync();
            var all_products = await products.GetAllAsync();
            var all_orders = await orders.GetAllAsync();

            foreach (var item in result)
            {
                payments.Add(Mappers.BLLMapper.MapPaymentToPayment_BLL(item, all_orders, all_users, all_products));
            }
            return payments;
        }

        //public async Task<Order_BLL> GetByIDAsync(int id) { };

        public async Task InsertObjAsync(Payment_BLL payment)//делаем запрос на вставку и передаем в сервис
        {

            await payment_source.InsertObjAsync(Mappers.BLLMapper.MapPayment_BLLToPayment(payment));
        }

        public async Task UpdateObjAsync(Payment_BLL payment)//тоже самое
        {

            await payment_source.UpdateObjAsync(Mappers.BLLMapper.MapPayment_BLLToPayment(payment));
        }
    }
}
