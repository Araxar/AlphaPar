using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Principal;
using System.Threading;

namespace AlphaParWindows
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            AuthenticateUser();
            
        }
        //[PrincipalPermission(SecurityAction.Demand, Role = "SomeDomain\\MyApplication-Administrator")]
        private void AuthenticateUser()
        {
            if (!Thread.CurrentPrincipal.Identity.IsAuthenticated ||
            !Thread.CurrentPrincipal.IsInRole("SomeDomain\\MyApplication-User"))
            {
                MessageBox.Show("Sorry, you do not have access to the application", "Access Denied");
                Application.Current.Shutdown();
            }
        }
    }
}
