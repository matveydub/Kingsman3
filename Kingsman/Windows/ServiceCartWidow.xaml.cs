using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

using Kingsman.DB;

namespace Kingsman.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceCartWidow.xaml
    /// </summary>
    public partial class ServiceCartWidow : Window
    {
        public ServiceCartWidow()
        {
            InitializeComponent();
            SetListViewItems();
        }

        public void SetListViewItems() 
        {
            ObservableCollection<DB.Service> listCart = new ObservableCollection<DB.Service>(ClassHelper.ServiceCartClass.serviceCart);
            LvServiceCart.ItemsSource = listCart.Distinct();
        }

        private void BtnDeleteCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service;

            service.Count = 0;

            ClassHelper.ServiceCartClass.serviceCart.Remove(service);

            SetListViewItems();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnCreateOrder_Click(object sender, RoutedEventArgs e)
        {

            DB.Order order = new DB.Order();
            order.OrderDate = DateTime.Now;
            order.EmployeeID = 1;

            //Window1 window1 = new Window1();
            //if (window1.userAuth != null)
            //{
            //    order.ClientID = window1.userAuth.ID;
            //}
            //else
            //{
            //    order.ClientID = window1.userAuth.ID;
            //}
            order.ClientID = 1;
            ClassHelper.EF.Context.Order.Add(order);
            ClassHelper.EF.Context.SaveChanges();

            foreach (var item in ClassHelper.ServiceCartClass.serviceCart.Distinct())
            {
                OrderService orderService = new OrderService();
                orderService.OrderID = order.ID;
                orderService.ServiceID = item.ID;
                orderService.Quantity = item.Count;

                ClassHelper.EF.Context.OrderService.Add(orderService);
                ClassHelper.EF.Context.SaveChanges();
            }

            MessageBox.Show("Заказ успешно оформлен");
        }
        
        private void BtnLowerCart_Click(object sender, RoutedEventArgs e)
        {
            
            var button = sender as Button;

            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service;

            if (service.Count > 1)
            {
                service.Count--;

                SetListViewItems();
            }

        }

        private void BtnHigherCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service;

            if (service.Count < 20)
            {
                service.Count++;

                SetListViewItems();
            }
        }
    }
}
