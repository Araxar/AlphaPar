using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace AlphaParWindows
{
    /// <summary>
    /// Logique d'interaction pour Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public ObservableCollection<Models.Employee> EmployeeList;
        private readonly string BaseAdress = "employees";
        public HttpClient HttpClient { get; set; }
        public Employees()
        {
            InitializeComponent();
            HttpClient = new HttpClient();
            var list = HttpClient.GetAll<List<Models.Employee>>(BaseAdress);
            EmployeeList = new ObservableCollection<Models.Employee>();
            list.ForEach(x => EmployeeList.Add(x));
            this.datagrid.ItemsSource = EmployeeList;
        }
        private void Searchbar_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = EmployeeList.Where((client) => client.Name.Contains(searchbar.Text) || client.Surname.Contains(searchbar.Text));
            
            this.datagrid.ItemsSource = filtered;
        }

        //private void btnDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    object item = datagrid.SelectedItem;
        //    string CourseName = (datagrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
        //    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the course " + CourseName + "?");
        //    if (result == MessageBoxResult.OK)
        //    {
        //        HttpClient.Delete(BaseAdress, );

        //        EmployeeList.RemoveAt(datagrid.SelectedIndex);                
        //    }
        //}

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Employee employee = new Employee();
            this.NavigationService.Navigate(employee, EmployeeList[datagrid.SelectedIndex]);
            // Some operations with this row
        }

        private void Menu_Emp_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }

        private void Menu_Cus_Click(object sender, RoutedEventArgs e)
        {
            Clients Clients = new Clients();
            this.NavigationService.Navigate(Clients);
        }
        private void Menu_Com_Click(object sender, RoutedEventArgs e)
        {
            Command Command = new Command();
            this.NavigationService.Navigate(Command);
        }
        private void Menu_Cha_Click(object sender, RoutedEventArgs e)
        {
            ProductionChains ProductionChains = new ProductionChains();
            this.NavigationService.Navigate(ProductionChains);
        }

    }
}
