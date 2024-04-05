using MyPrintDemo.BLL.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyPrintDemo.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public MyPrintDemo.BLL.Context context = new BLL.Context();
        public List<User_BLL> users = new List<User_BLL>();
        //public BLL.ListOfUsers users;
        public MainWindow()
        {
           // context = new BLL.Context();
          
            InitializeComponent();
           // users = context.Users.GetAllAsync().Result.ToList();

        }
    }
}