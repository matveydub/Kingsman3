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
    /// Логика взаимодействия для RedactEmployeeWindow.xaml
    /// </summary>
    public partial class RedactEmployeeWindow : Window
    {
        DB.Employee editEmployee = null;

        public RedactEmployeeWindow()
        {
            InitializeComponent();
        }

        public RedactEmployeeWindow(DB.Employee employee)
        {
            InitializeComponent();

            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "GenderName";
            //CmbGender.SelectedItem = ClassHelper.EF.Context.Gender.Where(i => i.GenderCode == employee.GenderCode);

            CmbPosition.ItemsSource = ClassHelper.EF.Context.Position.ToList();
            CmbPosition.DisplayMemberPath = "PositionName";
            //CmbPosition.SelectedItem = ClassHelper.EF.Context.Position.Where(i => i.ID == employee.PositionID);

            TbLogin.Text = employee.Login;
            TbPassword.Text = employee.Password;
            TbFirstName.Text = employee.FirstName;
            TbLastName.Text = employee.LastName;
            TbPatronymic.Text = employee.Patronymic;
            TbPhone.Text = employee.Phone;
            CmbGender.SelectedItem = ClassHelper.EF.Context.Gender.Where(i => i.GenderCode == employee.GenderCode).FirstOrDefault();
            CmbPosition.SelectedItem = ClassHelper.EF.Context.Position.Where(i => i.ID == employee.PositionID).FirstOrDefault();

            editEmployee = employee;
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            editEmployee.Login = TbLogin.Text;
            editEmployee.Password = TbPassword.Text;
            editEmployee.FirstName = TbFirstName.Text;
            editEmployee.LastName = TbLastName.Text;
            editEmployee.Phone = TbPhone.Text;
            editEmployee.GenderCode = (CmbGender.SelectedItem as DB.Gender).GenderCode;
            editEmployee.PositionID = (CmbPosition.SelectedItem as DB.Position).ID;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранены!");

            this.Close();
        }
    }
}
