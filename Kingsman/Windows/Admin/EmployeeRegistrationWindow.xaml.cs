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
    /// Логика взаимодействия для EmployeeRegistrationWindow.xaml
    /// </summary>
    public partial class EmployeeRegistrationWindow : Window
    {
        public EmployeeRegistrationWindow()
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";
            CmbGender.SelectedIndex = 0;

            CmbPosition.ItemsSource = ClassHelper.EF.Context.Position.ToList();
            CmbPosition.DisplayMemberPath = "PositionName";
            CmbPosition.SelectedIndex = 0;
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
            DB.Employee addEmployee = new DB.Employee();
            addEmployee.Login = TbLogin.Text;
            addEmployee.Password = PbPassword.Password;
            addEmployee.FirstName = TbFirstName.Text;
            addEmployee.LastName = TbLastName.Text;
            if (TbPatronymic.Text != string.Empty)
            {
                addEmployee.Patronymic = TbPatronymic.Text;
            }
            addEmployee.Phone = TbPhone.Text;
            addEmployee.GenderCode = (CmbGender.SelectedItem as DB.Gender).GenderCode;
            addEmployee.PositionID = (CmbPosition.SelectedItem as DB.Position).ID;
            ClassHelper.EF.Context.Employee.Add(addEmployee);

            //Confirmation
            ClassHelper.EF.Context.SaveChanges();
            MessageBox.Show("Регистрация сотрудника успешна!");
            this.Close(); 
        }
    }
}
