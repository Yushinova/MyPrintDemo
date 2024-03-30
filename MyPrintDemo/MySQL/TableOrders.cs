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
    public class TableOrders : ICrud<Order>
    {
        private readonly MySqlService<Order> _service;
        public TableOrders()
        {
            _service = new MySqlService<Order>();
        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _service.GetValuesAsync(Table_names.TABLE_ORDERS);
        }

        public Task<Order> GetByIDAsync(int id)//не понадобится
        {
            throw new NotImplementedException();
        }

        public async Task InsertObjAsync(Order obj)
        {
            string sql = $"""
insert into {Table_names.TABLE_ORDERS} ({TableOrdersColumns.DATE_ORDER},{TableOrdersColumns.USER_ID},{TableOrdersColumns.PRODUCT_ID})
values ('{obj.Date_order:yyyy-MM-dd HH:mm:ss}',{obj.User_ID},{obj.Product_ID})
""";
            await _service.UpdateAndInsertAsync(sql);
        }

        public async Task UpdateObjAsync(Order obj)
        {
            string sql = $"""
update {Table_names.TABLE_ORDERS} set {TableOrdersColumns.DATE_ORDER}='{obj.Date_order:yyyy-MM-dd HH:mm:ss}',
{TableOrdersColumns.ISPAID}={obj.IsPaid},{TableOrdersColumns.ISPRODUCTION}={obj.IsProduction},
{TableOrdersColumns.ISREADY}={obj.IsReady}
where {TableOrdersColumns.ID_ORDER}={obj.Id_order}
""";
            await _service.UpdateAndInsertAsync(sql);
        }
    }
}
