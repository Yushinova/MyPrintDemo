using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyPrintDemo.WPF
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly BLL.Context context;
        public UserWindow(BLL.Models.User_BLL user)
        {
            InitializeComponent();
            context = new BLL.Context();
            LoginUser.DataContext = user;
        }
            
       
    }
}
