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
        public IEnumerable<User> GetAllAsync()
        {
            return _service.GetValuesAsync(Table_names.TABLE_USERS);
        }

        public User GetByIDAsync(int id)
        {
            return _service.GetByIdAsync(Table_names.TABLE_USERS, TableUsersColumn.ID_USER, id);
        }

        public void InsertObjAsync(User obj)//делаем запрос на вставку и передаем в сервис
        {
string sql = $"""
insert into {Table_names.TABLE_USERS} ({TableUsersColumn.PASSWORD},{TableUsersColumn.LOGIN},{TableUsersColumn.NAME}, {TableUsersColumn.SURNAME}, {TableUsersColumn.PHONE})
values ('{obj.Password}','{obj.Login}', '{obj.Name}', '{obj.Surname}', '{obj.Phone}')
""";
            _service.UpdateAndInsertAsync(sql);
        }

        public void UpdateObjAsync(User obj)//тоже самое
        {
            string sql = $"""
update {Table_names.TABLE_USERS} set {TableUsersColumn.PASSWORD}='{obj.Password}', {TableUsersColumn.LOGIN}='{obj.Login}',
{TableUsersColumn.NAME}='{obj.Name}', {TableUsersColumn.SURNAME}='{obj.Surname}', {TableUsersColumn.PHONE}='{obj.Phone}'
""";
            _service.UpdateAndInsertAsync(sql);
        }
    }
}
