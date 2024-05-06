using MyPrintDemo.WPF.ViewModels;
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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public Order_view order_;
        public OrderWindow(Order_view order)
        {
            order_ = order;
            InitializeComponent();
            OrderGrid.DataContext = order_;
            SetImage();
        }

        public void SetImage()
        {
            foreach (var item in order_.images)
            {
                Image image = new Image();//на нашу кнопку для визуализации добавляем картинку
                image.Source = UserWindow.SetBitmap(item.Url);
                image.Height = 250;
                image.Width = 250;
                OrderImages.Children.Add(image);
                image.Margin = new Thickness(Left = 20);

            }
        }
        public void SetButton()
        {
            //делать стакпанел с кнопкаи для оплачен и для предварительный
            if(order_.IsPaid== "Не оплачен")//добавить кнопки Оплатить, Изменить, Удалить, Назад  и события на них!
            {
                //TO DO
            }
            else
            {
                //Назад
            }
        }
    }
}
