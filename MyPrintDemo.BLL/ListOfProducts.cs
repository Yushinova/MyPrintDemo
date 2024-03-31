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
    public class ListOfProducts
    {
        private ICrud<Product> product_source;
        public List<Product_BLL> products { get; }
        public ListOfProducts()
        {
            product_source = new TableProducts();
        }

        public async Task<IEnumerable<Product_BLL>> GetAllAsync()
        {
            var result = await product_source.GetAllAsync();
            foreach (var item in result)
            {
                products.Add(Mappers.BLLMapper.MapProductToProduct_BLL(item));
            }
            return products;
        }

        public async Task<Product_BLL> GetByIDAsync(int id)
        {
            var product = await product_source.GetByIDAsync(id);
            return Mappers.BLLMapper.MapProductToProduct_BLL(product);
        }

        public async Task InsertObjAsync(Product_BLL product)//делаем запрос на вставку и передаем в сервис
        {

            await product_source.InsertObjAsync(Mappers.BLLMapper.MapProduct_BLLToProduct(product));
        }

        public async Task UpdateObjAsync(Product_BLL product)//тоже самое
        {

            await product_source.UpdateObjAsync(Mappers.BLLMapper.MapProduct_BLLToProduct(product));
        }
    }
}
