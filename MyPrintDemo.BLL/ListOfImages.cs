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
    public class ListOfImages
    {
        private ICrud<Image_product> image_source;
       
        public ListOfImages()
        {
            image_source = new TableImages();
        }
        public IEnumerable<Image_BLL> GetAll()
        {
            List<Image_BLL> images = new List<Image_BLL>();
            var result = image_source.GetAll();
            TableOrders orders = new TableOrders();
            TableUsers users = new TableUsers();
            TableProducts products = new TableProducts();

            var all_users =  users.GetAll();
            var all_products =  products.GetAll();
            var all_orders =  orders.GetAll();

            foreach (var item in result)
            {
                images.Add(Mappers.BLLMapper.MapImageToImage_BLL(item, all_orders, all_users, all_products));
            }
            return images;
        }

        //public async Task<Order_BLL> GetByIDAsync(int id) { };

        public void InsertObj(Image_BLL image)//делаем запрос на вставку и передаем в сервис
        {

            image_source.InsertObj(Mappers.BLLMapper.MapImage_BLLToImage(image));
        }

        public void UpdateObj(Image_BLL image)//тоже самое
        {

            image_source.UpdateObj(Mappers.BLLMapper.MapImage_BLLToImage(image));
        }
    }
}
