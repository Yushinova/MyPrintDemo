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

        public IEnumerable<Product_BLL> GetAll()
        {
            var result = product_source.GetAll();
            foreach (var item in result)
            {
                products.Add(Mappers.BLLMapper.MapProductToProduct_BLL(item));
            }
            return products;
        }

        public Product_BLL GetByID(int id)
        {
            var product = product_source.GetByID(id);
            return Mappers.BLLMapper.MapProductToProduct_BLL(product);
        }

        public void InsertObj(Product_BLL product)//делаем запрос на вставку и передаем в сервис
        {

            product_source.InsertObj(Mappers.BLLMapper.MapProduct_BLLToProduct(product));
        }

        public void UpdateObj(Product_BLL product)//тоже самое
        {

            product_source.UpdateObj(Mappers.BLLMapper.MapProduct_BLLToProduct(product));
        }
    }
}
