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
    public class TablePayments : ICrud<Payment>
    {
        private readonly MySqlService<Payment> _service;
        public TablePayments()
        {
            _service = new MySqlService<Payment>();
        }
        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _service.GetValuesAsync(Table_names.TABLE_PAYMENTS);
        }

        public Task<Payment> GetByIDAsync(int id)//no
        {
            throw new NotImplementedException();
        }

        public async Task InsertObjAsync(Payment obj)
        {
            string sql = $"""
insert into {Table_names.TABLE_PAYMENTS} ({TablePaymentsColumns.SUM_PAYMENT},{TablePaymentsColumns.DATE_PAYMENT},{TablePaymentsColumns.ORDER_ID})
values ('{obj.Sum_payment}',{obj.Date_payment},{obj.Order_Id})
""";
            await _service.UpdateAndInsertAsync(sql);
        }

        public Task UpdateObjAsync(Payment obj)//no
        {
            throw new NotImplementedException();
        }
    }
}
