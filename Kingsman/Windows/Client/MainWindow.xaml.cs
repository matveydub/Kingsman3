using Kingsman.Windows.Admin;
using Kingsman.Windows.Client;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kingsman
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            this.Hide();
            serviceWindow.ShowDialog();
            this.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientsWindow clientsWindow = new ClientsWindow();
            this.Hide();
            clientsWindow.ShowDialog();
            this.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EmployeesWindow employeesWindow = new EmployeesWindow();
            this.Hide();
            employeesWindow.ShowDialog();
            this.Show();  
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ReportsWindow reportsWindow = new ReportsWindow();
            this.Hide();
            reportsWindow.ShowDialog();
            this.Show();
        }
    }
}
