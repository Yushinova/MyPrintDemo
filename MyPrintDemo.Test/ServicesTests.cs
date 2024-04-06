using MyPrintDemo.MySQL;
using MyPrintDemo.MySQL.TablesColumns;
using MyPrintDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyPrintDemo.Test
{
    public class ServicesTests
    {
        private List<Models.User> expected_users = new List<Models.User>()
        {
            new Models.User{ID_user=1, Password="110484tanya", Login="sulin_art@mail.ru", Name="Tanya", Surname="Yushinova", Phone="8-905-45-46-999"},
            new Models.User {ID_user=2, Password="208574yuy", Login="krecker@gmail.com", Name="Kolya", Surname="Pupkin", Phone="8-900-526-33-11"}
        };
        private List<Models.Order> expectes_orders = new List<Models.Order>()
        {
            new Models.Order{Id_order=1, Date_order=new DateTime(2024,3,28,13,27,33), IsPaid=0, IsProduction=0, IsReady=0, Product_ID=1, User_ID=1},
            new Models.Order{Id_order=2, Date_order=new DateTime(2024,3,28,13,27,33), IsPaid=0, IsProduction=0, IsReady=0, User_ID=1, Product_ID=3},
            new Models.Order{Id_order=3, Date_order=new DateTime(2024,3,28,13,27,33), IsPaid=0, IsProduction=0, IsReady=0, User_ID=2, Product_ID=2},
            new Models.Order{Id_order=4, Date_order=new DateTime(2024,3,30,21,36,15), IsPaid=1, IsProduction=1, IsReady=1, User_ID=2, Product_ID=3}
        };
        private MySqlService<Models.User> positive_service = new MySqlService<Models.User>();

        [Fact]
        public void GoodConfigTest()
        {
            Assert.NotNull(positive_service);
        }
        [Fact]
        public void BadConfigTest()
        {
           
            Assert.Throws<ArgumentException>(() =>
            {
                MySqlService<Models.User> mySqlService = new MySqlService<Models.User>("Bad_config");
            });
        }
        [Fact]
        public void GetValuesUser()
        {
            var actual_users = positive_service.GetValues(Table_names.TABLE_USERS);
            Assert.Equal(actual_users, expected_users);
        }
        [Fact]
        public void UpdateAndInsertUser()//вставляем тестового юзера и проверяем
        {
            string sql = $"""
insert into {Table_names.TABLE_USERS} ({TableUsersColumn.PASSWORD},{TableUsersColumn.LOGIN},{TableUsersColumn.NAME}, {TableUsersColumn.SURNAME}, {TableUsersColumn.PHONE})
values ('TEST','TEST', 'TEST', 'TEST', 'TEST')
""";
            positive_service.UpdateAndInsert(sql);
            var actual_users = positive_service.GetValues(Table_names.TABLE_USERS);
            actual_users.Contains(new Models.User { Login = "TEST" });
        }
        [Fact]
        public void GetValuesOder()
        {

        MySqlService<Models.Order> positive_service = new MySqlService<Models.Order>();
            var actual_orders = positive_service.GetValues(Table_names.TABLE_ORDERS);
            Assert.Equal(actual_orders, expectes_orders);
        }
        [Fact]
        public void UpdateAndInsertAsyncOrder()
        {
            Models.Order test = new Models.Order { Id_order = 4, Date_order = new DateTime(2024, 3, 30, 21, 36, 15), IsPaid = 1, IsProduction = 1, IsReady = 1, Product_ID = 2, User_ID = 3 };
            TableOrders orders = new TableOrders();
            orders.UpdateObj(test);
        }
    }
}
