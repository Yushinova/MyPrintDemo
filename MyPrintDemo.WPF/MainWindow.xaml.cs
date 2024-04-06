using MyPrintDemo.BLL.Models;
using MyPrintDemo.Models;
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
        private readonly BLL.Context context;
        public List<User_BLL> users;
        public User_BLL user;
        //public BLL.ListOfUsers users;
        public MainWindow()
        {

            InitializeComponent();
            context = new BLL.Context();
            users = new List<User_BLL>();
            user = new User_BLL();
            users = context.Users.GetAll().ToList();

        }
        private bool Sumbol_Error(string str)
        {
            if (str.Length > 0 && str.IndexOfAny(new char[] { '/', '*', '+', '&', '?', '.', ',', ' ', '!', '#', '$', '%', '^', '(', ')', '=', '<', '>' }) == -1)
            {
                return true;
            }
            return false;
        }
        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            MainGrid.Visibility = Visibility.Hidden;
            RegistrGrig.Visibility = Visibility.Visible;
        }

        private void AuthoButtonClick(object sender, RoutedEventArgs e)
        {
            MainGrid.Visibility = Visibility.Hidden;
            AuthorGrid.Visibility = Visibility.Visible;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainGrid.Visibility = Visibility.Visible;
            AuthorGrid.Visibility = Visibility.Hidden;
            RegistrGrig.Visibility = Visibility.Hidden;
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            if (Sumbol_Error(LoginRegistr.Text) & Sumbol_Error(PasswordRegistr.Text)
                & Sumbol_Error(NamedRegistr.Text) & Sumbol_Error(SurnameRegistr.Text)
                & Sumbol_Error(PhoneRegistr.Text))
            {
                user.Login = LoginRegistr.Text;
                user.Password = PasswordRegistr.Text;
                user.Name = NamedRegistr.Text;
                user.Surname = NamedRegistr.Text;
                user.Phone = PhoneRegistr.Text;
                if (users.Exists(u => u.Login == LoginRegistr.Text))
                {
                    MessageBox.Show("Такой пользователь существует", "Ошибка регистрации",
               MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    context.Users.InsertObj(user);
                    users.Clear();
                    users = context.Users.GetAll().ToList();
                    UserWindow window = new UserWindow(user);
                    window.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Недопустимый символ", "Ошибка регистрации",
          MessageBoxButton.OK, MessageBoxImage.Error);
                LoginRegistr.Clear();
                PasswordRegistr.Clear();
                NamedRegistr.Clear();
                SurnameRegistr.Clear();
                PhoneRegistr.Clear();
            }

        }

        private void AuthorClick(object sender, RoutedEventArgs e)
        {
            if (users.Exists(u => u.Login == LoginAuthoriz.Text && u.Password == PasswordAuthoriz.Text))
            {
                MessageBox.Show("Добро пожаловать", $"{LoginAuthoriz.Text}",
           MessageBoxButton.OK, MessageBoxImage.Information);
                user = context.Users.GetByLogin(LoginAuthoriz.Text);
                //Test.Text = user.Login;
                UserWindow window = new UserWindow(user);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка регистрации",
               MessageBoxButton.OK, MessageBoxImage.Error);
                LoginAuthoriz.Clear();
                PasswordAuthoriz.Clear();
            }
        }
    }
}