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
        public async Task<IEnumerable<User_BLL>> GetAllAsync()
        {
           var result = await user_source.GetAllAsync();
            foreach (var item in result)
            {
                users.Add(Mappers.BLLMapper.MapUserToUser_BLL(item));
            }
            return users;
        }

        public async Task<User_BLL> GetByLoginAsync(string login)//поиск по логину
        {
            var result = await user_source.GetAllAsync();
            var user = result.First(r => r.Login == login);
           return Mappers.BLLMapper.MapUserToUser_BLL(user);

        }

        public async Task<User_BLL> GetByIDAsync(int id)
        {
           var user =await user_source.GetByIDAsync(id);
            return Mappers.BLLMapper.MapUserToUser_BLL(user);
        }

        public async Task InsertObjAsync(User_BLL user)//делаем запрос на вставку и передаем в сервис
        {

            await user_source.InsertObjAsync(Mappers.BLLMapper.MapUser_BLLToUser(user));
        }

        public async Task UpdateObjAsync(User_BLL user)//тоже самое
        {

            await user_source.UpdateObjAsync(Mappers.BLLMapper.MapUser_BLLToUser(user));
        }
    }
}
