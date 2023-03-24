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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";
            CmbGender.SelectedIndex = 0;


        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            //Validation
            if (string.IsNullOrEmpty(TbLogin.Text))
            {
                MessageBox.Show("Ошибка! Пустое поле!");
                return;
            }
            if (string.IsNullOrEmpty(PbPassword.Password))
            {
                MessageBox.Show("Ошибка! Пустое поле!");
                return;
            }
            if (string.IsNullOrEmpty(TbFirstName.Text))
            {
                MessageBox.Show("Ошибка! Пустое поле!");
                return;
            }
            if (string.IsNullOrEmpty(TbLastName.Text))
            {
                MessageBox.Show("Ошибка! Пустое поле!");
                return;
            }
            if (string.IsNullOrEmpty(TbPhone.Text))
            {
                MessageBox.Show("Ошибка! Пустое поле!");
                return;
            }
            //Cjpasdf GOod boy
            DB.Client addClient = new DB.Client();
            addClient.Login = TbLogin.Text;
            addClient.Password = PbPassword.Password;
            addClient.FirstName = TbFirstName.Text;
            addClient.LastName = TbLastName.Text;
            if (TbPatronymic.Text != string.Empty)
            {
                addClient.Patronymic = TbPatronymic.Text;
            }
            addClient.Phone = TbPhone.Text;
            addClient.GenderCode = (CmbGender.SelectedItem as DB.Gender).GenderCode;
            ClassHelper.EF.Context.Client.Add(addClient);

            //Confirmation
            ClassHelper.EF.Context.SaveChanges();
            MessageBox.Show("Регистрация успешна!");
        }
    }
}
