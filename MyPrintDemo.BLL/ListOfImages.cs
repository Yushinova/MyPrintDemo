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
        public List<Image_BLL> images { get; }
        public ListOfImages()
        {
            image_source = new TableImages();
        }
        public IEnumerable<Image_BLL> GetAllAsync()
        {
            var result = image_source.GetAllAsync();
            TableOrders orders = new TableOrders();
            TableUsers users = new TableUsers();
            TableProducts products = new TableProducts();

            var all_users =  users.GetAllAsync();
            var all_products =  products.GetAllAsync();
            var all_orders =  orders.GetAllAsync();

            foreach (var item in result)
            {
                images.Add(Mappers.BLLMapper.MapImageToImage_BLL(item, all_orders, all_users, all_products));
            }
            return images;
        }

        //public async Task<Order_BLL> GetByIDAsync(int id) { };

        public void InsertObjAsync(Image_BLL image)//делаем запрос на вставку и передаем в сервис
        {

            image_source.InsertObjAsync(Mappers.BLLMapper.MapImage_BLLToImage(image));
        }

        public void UpdateObjAsync(Image_BLL image)//тоже самое
        {

            image_source.UpdateObjAsync(Mappers.BLLMapper.MapImage_BLLToImage(image));
        }
    }
}
