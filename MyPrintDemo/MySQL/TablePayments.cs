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
    public class TablePayments : ICrud<Payment>
    {
        private readonly MySqlService<Payment> _service;
        public TablePayments()
        {
            _service = new MySqlService<Payment>();
        }
        public IEnumerable<Payment> GetAll()
        {
            return _service.GetValues(Table_names.TABLE_PAYMENTS);
        }

        public Payment GetByID(int id)//no
        {
            throw new NotImplementedException();
        }

        public void InsertObj(Payment obj)
        {
            string sql = $"""
insert into {Table_names.TABLE_PAYMENTS} ({TablePaymentsColumns.SUM_PAYMENT},{TablePaymentsColumns.DATE_PAYMENT},{TablePaymentsColumns.ORDER_ID})
values ({obj.Sum_payment},'{obj.Date_payment:yyyy-MM-dd hh:mm:ss}',{obj.Order_Id})
""";
            _service.UpdateAndInsert(sql);
        }

        public void UpdateObj(Payment obj)//no
        {
            throw new NotImplementedException();
        }
    }
}
