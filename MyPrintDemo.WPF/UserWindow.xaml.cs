using MyPrintDemo.BLL.Models;
using MyPrintDemo.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Printing;
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
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;

namespace MyPrintDemo.WPF
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly BLL.Context context;
        public ObservableCollection<Order_view> orders = new ObservableCollection<Order_view>();
        public ObservableCollection<Product_view> products = new ObservableCollection<Product_view>();
        public List<Order_BLL> order_BLLs = new List<Order_BLL>();
        public List<Image_BLL> image_BLLs = new List<Image_BLL>();
        public List<Product_BLL> product_BLLs = new List<Product_BLL>();
        public Order_BLL order_BLL = new Order_BLL();
        public User_BLL user_BLL = new User_BLL();
        public UserWindow(BLL.Models.User_BLL user)
        {
            InitializeComponent();
            context = new BLL.Context();
            order_BLLs = context.Orders.GetAll().ToList();
            image_BLLs = context.Images.GetAll().ToList();
            product_BLLs = context.Products.GetAll().ToList();
            foreach (var item in product_BLLs)
            {
                products.Add(Mappers.WPFMapper.MapProduct_BLLToProduct_view(item));
            }
            foreach (var item in order_BLLs)
            {
                if(item.user_bll.ID_user==user.ID_user)
                {
                    orders.Add(Mappers.WPFMapper.MapOrder_BLLToOrder_view(item, image_BLLs));
                }    
            }
            LoginUser.DataContext = user;
            NameUser.DataContext = user;
            OrdersDataGrid.ItemsSource = orders;
            ProductBox.ItemsSource = products;
            user_BLL = user;
        }

        private void OrdersDataGrid_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Selected_Product(object sender, EventArgs e)
        {
            Product_view? product = ProductBox.SelectedItem as Product_view;
            NewOrder.Visibility = Visibility.Visible;
           
            Product_BLL product_BLL = product_BLLs.First(p => p.Id_product == product.Id);
            NameProduct.DataContext = product;
            Prise.Text = $"{product_BLL.Cost_product} руб.";
            order_BLL = new Order_BLL { Date_order = DateTime.Now, user_bll = user_BLL, product_bll = product_BLL };//
            //test.Text = user_BLL.ID_user.ToString();
            context.Orders.InsertObj(order_BLL);//заказ вставился но я не знаю id
        }

        private void Selected_Color(object sender, EventArgs e)
        {
            if(Count_Images.SelectedIndex==0) { SecondImage.Visibility = Visibility.Hidden; }
            else {  SecondImage.Visibility = Visibility.Visible; }
            //test.Text = sender.ToString();
        }
        public BitmapImage SetBitmap(string path)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bi.UriSource = new Uri(path);
            bi.EndInit();
            return bi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();//диалоговое окно
            dialog.FileName = "Image"; // Default file name
            dialog.DefaultExt = ".jpg"; // Default file extension
            dialog.Filter = "Image (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                FileInfo f = new FileInfo(dialog.FileName);
                string path = f.FullName;
                // Path = dialog.FileName;
                BitmapImage save = new BitmapImage(new Uri(path));
                JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();//сохранение картинки в папке программы
                jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(save));
                string save_url = @"C:\Users\User\source\repos\MyPrintDemo\MyPrintDemo.WPF\Images\" + System.IO.Path.GetFileName(path);
                using (FileStream fileStream = new FileStream(save_url, FileMode.Create))//Images папка проекта
                    jpegBitmapEncoder.Save(fileStream);
                test.Text = order_BLL.Id_order.ToString();
                //Image_BLL image_BLL = new Image_BLL { Url = save_url, order = order_BLL };//узнать id этого нового заказа
                //context.Images.InsertObj(image_BLL);
                Image image = new Image();//на нашу кнопку для визуализации добавляем картинку
                image.Source = SetBitmap(save_url);
                ((sender as Button).Parent as StackPanel).Children.Add(image);
            }
        }
    }
}
