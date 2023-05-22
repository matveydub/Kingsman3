using Kingsman.DB;
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
using System.Windows.Shapes;

namespace Kingsman.Windows.Admin
{
    /// <summary>
    /// Логика взаимодействия для ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ClientsWindow()
        {
            InitializeComponent();
            LvClient.ItemsSource = ClassHelper.EF.Context.Client.ToList();
        }

        private void BtnRedactUser_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;

            if (button == null)
            {
                return;
            }
            var client = button.DataContext as DB.Client;


            RedactClientWindow redactClientWindow = new RedactClientWindow(client);
            redactClientWindow.Show();
            this.Close();
        }

        private void BtnAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();
        }
    }
}
