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
    public class TableImages : ICrud<Image_product>
    {
        private readonly MySqlService<Image_product> _service;
        public TableImages()
        {
            _service = new MySqlService<Image_product>();
        }
        public IEnumerable<Image_product> GetAllAsync()
        {
            return _service.GetValuesAsync(Table_names.TABLE_IMAGES);
        }

        public Image_product GetByIDAsync(int id)//no
        {
            throw new NotImplementedException();
        }

        public void InsertObjAsync(Image_product obj)
        {
            string sql = $"""
insert into {Table_names.TABLE_IMAGES} ({TableImagesColumn.URL},{TableImagesColumn.ORDER_ID})
values ('{obj.Url}',{obj.Order_ID})
""";
            _service.UpdateAndInsertAsync(sql);
        }

        public void UpdateObjAsync(Image_product obj)
        {
            string sql = $"update {Table_names.TABLE_IMAGES} set {TableImagesColumn.URL}={obj.Url} where ID_image={obj.Id_image}";

            _service.UpdateAndInsertAsync(sql);
        }
    }
}
