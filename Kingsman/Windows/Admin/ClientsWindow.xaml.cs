using Kingsman.DB;
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
        //List<Person> listPerson = new List<Person>();
        public ClientsWindow()
        {
            InitializeComponent();
            //Person person1 = new Person("Анастасия", "Абакумова", "Игоревна", 19);
            //Person person2 = new Person("Андрей",  "Петров",  "Дмитриевич", 20);
            //Person person3 = new Person("Максим", "Калмыков", "Львович", 21);
            //listPerson.Add(person1);
            //listPerson.Add(person2);
            //listPerson.Add(person3);
            DgClients.ItemsSource = ClassHelper.EF.Context.Client.ToList();
        }
        //private void Window_Loaded()
        //{
        //    var query =
        //    from client in ClassHelper.EF.Context.Client
        //    select new {client.FirstName, client.LastName, client.Patronymic, client.Phone};

        //    DgClients.ItemsSource = query.ToList();
        //}
        //public void getPerson()
        //{
        //    DgClients.ItemsSource = listPerson;
        //}
    }
    //public class Person
    //{
    //    public string firstName { get; set; }
    //    public string lastName { get; set; }
    //    public string patronymic { get; set; }
    //    public int age { get; set; }
    //    public Person(string firstName, string lastName, string patronymic, int age)
    //    {
    //        this.firstName = firstName;
    //        this.lastName = lastName;
    //        this.patronymic = patronymic;
    //        this.age = age;
    //    }
    //}
}
