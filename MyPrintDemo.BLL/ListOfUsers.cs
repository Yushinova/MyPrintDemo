using MyPrintDemo.BLL.Models;
using MyPrintDemo.Models;
using MyPrintDemo.MySQL;
using MyPrintDemo.MySQL.TablesColumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintDemo.BLL
{
    public class ListOfUsers
    {
        private ICrud<User> user_source;
        public List<User_BLL> users = new List<User_BLL>();
        public ListOfUsers()
        {
            user_source = new TableUsers();
        }
        public IEnumerable<User_BLL> GetAll()
        {
           var result = user_source.GetAll();
            foreach (var item in result)
            {
                users.Add(Mappers.BLLMapper.MapUserToUser_BLL(item));
            }
            return users;
        }

        public User_BLL GetByLogin(string login)//поиск по логину
        {
            var result = user_source.GetAll();
            var user = result.First(r => r.Login == login);
           return Mappers.BLLMapper.MapUserToUser_BLL(user);

        }

        public User_BLL GetByID(int id)
        {
           var user = user_source.GetByID(id);
            return Mappers.BLLMapper.MapUserToUser_BLL(user);
        }

        public void InsertObj(User_BLL user)//делаем запрос на вставку и передаем в сервис
        {

            user_source.InsertObj(Mappers.BLLMapper.MapUser_BLLToUser(user));
        }

        public void UpdateObj(User_BLL user)//тоже самое
        {

            user_source.UpdateObj(Mappers.BLLMapper.MapUser_BLLToUser(user));
        }
    }
}
