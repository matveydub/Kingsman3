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
    /// Логика взаимодействия для EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        public EmployeesWindow()
        {
            InitializeComponent();
            LvEmployee.ItemsSource = ClassHelper.EF.Context.Employee.ToList();
        }

        private void BtnRedactUser_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
            {
                return;
            }
            var employee = button.DataContext as DB.Employee;


            RedactEmployeeWindow redactEmployeeWindow = new RedactEmployeeWindow(employee);
            redactEmployeeWindow.Show();
            this.Close();
        }

        private void BtnAddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeRegistrationWindow employeeRegistration = new EmployeeRegistrationWindow();
            employeeRegistration.ShowDialog();
        }
    }
}
