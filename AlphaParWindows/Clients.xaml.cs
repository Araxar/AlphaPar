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
    /// Logique d'interaction pour Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        List<Clients> _clients;
        public Clients()
        {
            InitializeComponent();
            this.Title = $"Client Window - {System.Security.Principal.WindowsIdentity.GetCurrent().Name}";
        }

        private void Searchbar_KeyUp(object sender, KeyEventArgs e)
        {
            //var filtered = _clients.Where(client => client.Name.StartsWith(searchbar.Text));

            //datagrid.ItemsSource = filtered;
        }
    }
    
}
