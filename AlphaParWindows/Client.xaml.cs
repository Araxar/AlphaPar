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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlphaParWindows
{
    /// <summary>
    /// Logique d'interaction pour Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Menu_Emp_Click(object sender, RoutedEventArgs e)
        {
            Employees employees = new Employees();
            this.NavigationService.Navigate(employees);
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
