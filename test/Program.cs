// See https://aka.ms/new-console-template for more information
using MyPrintDemo.BLL.Models;

Console.WriteLine("Hello, World!");
MyPrintDemo.BLL.Context context = new MyPrintDemo.BLL.Context();
List<User_BLL> users = new List<User_BLL>();
users = context.Users.GetAllAsync().ToList();
Console.WriteLine(users.Count);
//MyPrintDemo.BLL.Models.User_BLL user = new MyPrintDemo.BLL.Models.User_BLL();
//user = context.Users.GetByIDAsync(1).Result;
//Console.WriteLine(user.Name);
