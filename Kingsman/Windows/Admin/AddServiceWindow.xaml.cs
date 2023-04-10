using Kingsman.DB;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddServiceWindow.xaml
    /// </summary>
    public partial class AddServiceWindow : Window
    {
        private string ImgService = null;
        public AddServiceWindow()
        {
            InitializeComponent();
            CmbServiceType.ItemsSource = ClassHelper.EF.Context.ServiceType.ToList();
            CmbServiceType.DisplayMemberPath = "TypeName";
            CmbServiceType.SelectedIndex = 0;
        }

        private void BtnAddServiceImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgImageService.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                ImgService = openFileDialog.FileName;
            }
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            Service service = new Service();
            service.ServiceName = TbServiceName.Text;
            service.Description = TbServiceDesc.Text;
            service.Price = Convert.ToDecimal(TbPrice.Text);
            service.Image = ImgService;
            service.ServiceTypeID = (CmbServiceType.SelectedItem as ServiceType).ID;

            ClassHelper.EF.Context.Service.Add(service);
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Услуга успешно добавлена!");
        }
    }
}
