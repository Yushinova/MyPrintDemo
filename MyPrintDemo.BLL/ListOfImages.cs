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
        public async Task<IEnumerable<Image_BLL>> GetAllAsync()
        {
            var result = await image_source.GetAllAsync();
            TableOrders orders = new TableOrders();
            TableUsers users = new TableUsers();
            TableProducts products = new TableProducts();

            var all_users = await users.GetAllAsync();
            var all_products = await products.GetAllAsync();
            var all_orders = await orders.GetAllAsync();

            foreach (var item in result)
            {
                images.Add(Mappers.BLLMapper.MapImageToImage_BLL(item, all_orders, all_users, all_products));
            }
            return images;
        }

        //public async Task<Order_BLL> GetByIDAsync(int id) { };

        public async Task InsertObjAsync(Image_BLL image)//делаем запрос на вставку и передаем в сервис
        {

            await image_source.InsertObjAsync(Mappers.BLLMapper.MapImage_BLLToImage(image));
        }

        public async Task UpdateObjAsync(Image_BLL image)//тоже самое
        {

            await image_source.UpdateObjAsync(Mappers.BLLMapper.MapImage_BLLToImage(image));
        }
    }
}
