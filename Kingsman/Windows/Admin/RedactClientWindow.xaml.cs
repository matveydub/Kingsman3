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
    /// Логика взаимодействия для RedactClientWindow.xaml
    /// </summary>
    public partial class RedactClientWindow : Window
    {
        DB.Client editClient = null;

        public RedactClientWindow()
        {
            InitializeComponent();
        }

        public RedactClientWindow(DB.Client client)
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";

            TbLogin.Text = client.Login;
            PbPassword.Password = client.Password;
            TbFirstName.Text = client.FirstName;
            TbLastName.Text = client.LastName;
            TbPatronymic.Text = client.Patronymic;
            TbPhone.Text = client.Phone;
            CmbGender.SelectedItem = ClassHelper.EF.Context.Gender.Where(i => i.GenderCode == client.GenderCode).FirstOrDefault();

            editClient = client;
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            editClient.Login = TbLogin.Text;
            editClient.Password = PbPassword.Password;
            editClient.FirstName = TbFirstName.Text;
            editClient.LastName = TbLastName.Text;
            editClient.Phone = TbPhone.Text;
            editClient.GenderCode = (CmbGender.SelectedItem as DB.Gender).GenderCode;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранены!");

            this.Close();
        }
    }
}
