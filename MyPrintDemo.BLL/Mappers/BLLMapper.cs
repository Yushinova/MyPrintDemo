using MyPrintDemo.BLL.Models;
using MyPrintDemo.Models;

namespace MyPrintDemo.BLL.Mappers
{
    public static class BLLMapper
    {
        public static User_BLL MapUserToUser_BLL(User user)
        {
            return new User_BLL()
            {
                ID_user = user.ID_user,
                Password = user.Password,
                Login = user.Login,
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.Phone
            };
        }

        public static User MapUser_BLLToUser(User_BLL user)
        {
            return new User()
            {
                ID_user = user.ID_user,
                Password = user.Password,
                Login = user.Login,
                Name = user.Name,
                Surname = user.Surname,
                Phone = user.Phone
            };
        }

        public static Product_BLL MapProductToProduct_BLL(Product product)
        {
            return new Product_BLL()
            {
                Id_product = product.Id_product,
                Name_product = product.Name_product,
                Height = product.Height,
                Width = product.Width,
                Count_product = product.Count_product,
                Cost_product = product.Cost_product,
                IsActuality = product.IsActuality
            };
        }

        public static Product MapProduct_BLLToProduct(Product_BLL product)
        {
            return new Product()
            {
                Id_product = product.Id_product,
                Name_product = product.Name_product,
                Height = product.Height,
                Width = product.Width,
                Count_product = product.Count_product,
                Cost_product = product.Cost_product,
                IsActuality = product.IsActuality
            };
        }

        public static Order_BLL MapOrderToOrder_BLL(Order order, IEnumerable<User> users, IEnumerable<Product> products)
        {
            return new Order_BLL()
            {
                Id_order = order.Id_order,
                Date_order = order.Date_order,
                IsPaid = order.IsPaid,
                IsProduction = order.IsProduction,
                IsReady = order.IsReady,
                user_bll = MapUserToUser_BLL(users.First(u => u.ID_user == order.User_ID)),
                product_bll = MapProductToProduct_BLL(products.First(p => p.Id_product == order.Product_ID))
            };
        }

        public static Order MapOrder_BLLToOrder(Order_BLL order)
        {
            return new Order()
            {
                Id_order = order.Id_order,
                Date_order = order.Date_order,
                IsPaid = order.IsPaid,
                IsProduction = order.IsProduction,
                IsReady = order.IsReady,
                User_ID = order.user_bll.ID_user,
                Product_ID = order.product_bll.Id_product
            };
        }

        public static Image_BLL MapImageToImage_BLL(Image_product image, IEnumerable<Order> orders, IEnumerable<User> users, IEnumerable<Product> products)
        {
            List<Order_BLL> orders_bll = new List<Order_BLL>();
            foreach (Order order in orders) { orders_bll.Add(MapOrderToOrder_BLL(order, users, products)); }
            return new Image_BLL()
            {
                Id_image = image.Id_image,
                Url = image.Url,
                order = orders_bll.First(o => o.Id_order == image.Order_ID)

            };
        }

        public static Image_product MapImage_BLLToImage(Image_BLL image)
        {
            return new Image_product()
            {
                Id_image = image.Id_image,
                Url = image.Url,
                Order_ID = image.order.Id_order
            };
        }

        public static Payment_BLL MapPaymentToPayment_BLL(Payment payment, IEnumerable<Order> orders, IEnumerable<User> users, IEnumerable<Product> products)
        {
            List<Order_BLL> orders_bll = new List<Order_BLL>();
            foreach (Order order in orders) { orders_bll.Add(MapOrderToOrder_BLL(order, users, products)); }
            return new Payment_BLL()
            {
                Id_payment = payment.Id_payment,
                Sum_payment = payment.Sum_payment,
                Date_payment = payment.Date_payment,
                order = orders_bll.First(o => o.Id_order == payment.Order_Id)
            };
        }

        public static Payment MapPayment_BLLToPayment(Payment_BLL payment)
        {
            return new Payment()
            {
                Id_payment = payment.Id_payment,
                Sum_payment = payment.Sum_payment,
                Date_payment = payment.Date_payment,
                Order_Id = payment.order.Id_order
            };
        }
    }
}
