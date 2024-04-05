using MyPrintDemo.Models;
using MyPrintDemo.MySQL.TablesColumns;
using MyPrintDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.MySQL
{
    public class TableProducts : ICrud<Product>
    {
        private readonly MySqlService<Product> _service;
        public TableProducts()
        {
            _service = new MySqlService<Product>();
        }
        public IEnumerable<Product> GetAllAsync()
        {
            return _service.GetValuesAsync(Table_names.TABLE_PRODUCTS);
        }

        public Product GetByIDAsync(int id)
        {
            return _service.GetByIdAsync(Table_names.TABLE_PRODUCTS, TableProductsColumn.ID_PRODUCT, id);
        }

        public void InsertObjAsync(Product obj)//делаем запрос на вставку и передаем в сервис
        {
            string sql = $"""
insert into {Table_names.TABLE_PRODUCTS} ({TableProductsColumn.NAME_PRODUCT},{TableProductsColumn.HEIGHT},
{TableProductsColumn.WIDTH}, {TableProductsColumn.COUNT_PRODUCT}, {TableProductsColumn.COST_PRODUCT})
values ('{obj.Name_product}',{obj.Height}, {obj.Width}, {obj.Count_product}, {obj.Count_product})
""";
            _service.UpdateAndInsertAsync(sql);
        }

        public void UpdateObjAsync(Product obj)//тоже самое
        {
            string sql = $"""
update {Table_names.TABLE_PRODUCTS} set {TableProductsColumn.NAME_PRODUCT}='{obj.Name_product}',
{TableProductsColumn.HEIGHT}={obj.Height},{TableProductsColumn.WIDTH}={obj.Width},
{TableProductsColumn.COUNT_PRODUCT}={obj.Count_product}, {TableProductsColumn.COST_PRODUCT}={obj.Cost_product}
where {TableProductsColumn.ID_PRODUCT}={obj.Id_product}
""";
            _service.UpdateAndInsertAsync(sql);
        }
    }
}
