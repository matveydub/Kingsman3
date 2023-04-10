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

namespace Kingsman.Windows.Employee
{
    /// <summary>
    /// Логика взаимодействия для RedactServiceWindow.xaml
    /// </summary>
    public partial class RedactServiceWindow : Window
    {
        DB.Service editService = null;

        public RedactServiceWindow()
        {
            InitializeComponent();
        }

        public RedactServiceWindow(DB.Service service) 
        {
            InitializeComponent();

            ImgImageService.Source = new BitmapImage(new Uri(service.Image));

            TbServiceName.Text = service.ServiceName;
            TbServiceDesc.Text = service.Description;
            TbPrice.Text = Convert.ToString(service.Price);

            CmbServiceType.ItemsSource = ClassHelper.EF.Context.ServiceType.ToList();
            CmbServiceType.DisplayMemberPath = "TagName";

            CmbServiceType.SelectedItem = ClassHelper.EF.Context.ServiceType.Where(i => i.ID == service.ServiceTypeID);

            editService = service;
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            editService.ServiceName = TbServiceName.Text;
            editService.Description = TbServiceDesc.Text;

            editService.Price = Convert.ToDecimal(TbPrice.Text);
            editService.ServiceTypeID = (CmbServiceType.SelectedItem as DB.ServiceType).ID;

            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Данные успешно сохранены!");

            this.Close();
        }

        private void BtnAddServiceImage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
