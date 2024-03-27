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
    public class TableUsers : ICrud<User>
    {
        private readonly MySqlService<User> _service;
        public TableUsers()
        {
            _service = new MySqlService<User>();
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _service.GetValuesAsync(Table_names.TABLE_USERS);
        }

        public async Task<User> GetByIDAsync(int id)
        {
            return await _service.GetByIdAsync(Table_names.TABLE_USERS, TableUsersColumn.ID_USER, id);
        }

        public async Task InsertObjAsync(User obj)//делаем запрос на вставку и передаем в сервис
        {
string sql = $"""
insert into {Table_names.TABLE_USERS} ({TableUsersColumn.PASSWORD},{TableUsersColumn.LOGIN},{TableUsersColumn.NAME}, {TableUsersColumn.SURNAME}, {TableUsersColumn.PHONE})
values ('{obj.Password}','{obj.Login}', '{obj.Name}', '{obj.Surname}', '{obj.Phone}')
""";
            await _service.UpdateAndInsertAsync(sql);
        }

        public Task UpdateObj(User obj)//тоже самое
        {
            throw new NotImplementedException();
        }
    }
}
