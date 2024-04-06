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
        
        public ListOfPayments()
        {
            payment_source = new TablePayments();
        }
        public IEnumerable<Payment_BLL> GetAll()
        {
            List<Payment_BLL> payments = new List<Payment_BLL>();
            var result = payment_source.GetAll();
            TableOrders orders = new TableOrders();
            TableUsers users = new TableUsers();
            TableProducts products = new TableProducts();

            var all_users = users.GetAll();
            var all_products =  products.GetAll();
            var all_orders = orders.GetAll();

            foreach (var item in result)
            {
                payments.Add(Mappers.BLLMapper.MapPaymentToPayment_BLL(item, all_orders, all_users, all_products));
            }
            return payments;
        }

        //public async Task<Order_BLL> GetByIDAsync(int id) { };

        public void InsertObj(Payment_BLL payment)//делаем запрос на вставку и передаем в сервис
        {

            payment_source.InsertObj(Mappers.BLLMapper.MapPayment_BLLToPayment(payment));
        }

        public void UpdateObj(Payment_BLL payment)//тоже самое
        {

            payment_source.UpdateObj(Mappers.BLLMapper.MapPayment_BLLToPayment(payment));
        }
    }
}
