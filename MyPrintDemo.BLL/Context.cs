using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.BLL
{
    public class Context
    {
        public ListOfUsers Users { get; }
        public ListOfProducts Products { get; }
        public ListOfOrders Orders { get; }
        public ListOfImages Images { get; }
        public ListOfPayments Payments { get; }
        public Context()
        {
            Users = new ListOfUsers();
            Products = new ListOfProducts();
            Orders = new ListOfOrders();
            Images = new ListOfImages();
            Payments = new ListOfPayments();
        }
    }
}
