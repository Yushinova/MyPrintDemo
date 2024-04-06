﻿using MyPrintDemo.Models;
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
        public IEnumerable<Order> GetAll()
        {
            return _service.GetValues(Table_names.TABLE_ORDERS);
        }

        public Order GetByID(int id)//не понадобится
        {
            throw new NotImplementedException();
        }

        public void InsertObj(Order obj)
        {
            string sql = $"""
insert into {Table_names.TABLE_ORDERS} ({TableOrdersColumns.DATE_ORDER},{TableOrdersColumns.USER_ID},{TableOrdersColumns.PRODUCT_ID})
values ('{obj.Date_order}',{obj.User_ID},{obj.Product_ID})
""";
            _service.UpdateAndInsert(sql);
        }

        public void UpdateObj(Order obj)
        {
            string sql = $"""
update {Table_names.TABLE_ORDERS} set {TableOrdersColumns.DATE_ORDER}='{obj.Date_order}',
{TableOrdersColumns.ISPAID}={obj.IsPaid},{TableOrdersColumns.ISPRODUCTION}={obj.IsProduction},
{TableOrdersColumns.ISREADY}={obj.IsReady}
where {TableOrdersColumns.ID_ORDER}={obj.Id_order}
""";
            _service.UpdateAndInsert(sql);
        }
    }
}
