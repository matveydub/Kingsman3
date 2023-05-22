using Kingsman.ClassHelper;
using Kingsman.Windows.Admin;
using Kingsman.Windows.Employee;
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

namespace Kingsman.Windows.Client
{
    /// <summary>
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        public ServiceWindow()
        {
            InitializeComponent();
            GetListService();
        }
        public void GetListService()
        {
            LvService.ItemsSource = ClassHelper.EF.Context.Service.ToList();
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddServiceWindow serviceWindow = new AddServiceWindow();
            this.Close();
            serviceWindow.ShowDialog();
            GetListService();
        }

        private void BtnRedactService_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service;

            RedactServiceWindow redactServiceWindow = new RedactServiceWindow(service);
            redactServiceWindow.ShowDialog();
            GetListService();
        }

        private void BtnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DB.Service;

            
            service.Count++;
            ServiceCartClass.serviceCart.Add(service);

        }

        private void BtnServiceCart_Click(object sender, RoutedEventArgs e)
        {
            ServiceCartWidow serviceCartWidow = new ServiceCartWidow();
            this.Hide();
            serviceCartWidow.ShowDialog();
            this.Show();
        }
    }
}
