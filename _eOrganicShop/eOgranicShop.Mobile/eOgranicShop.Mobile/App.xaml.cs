using eOgranicShop.Mobile.Services;
using eOgranicShop.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eOgranicShop.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTc4OTAxQDMxMzkyZTMzMmUzMEcxWEtrVnNpY1NNcVYzQ0llR3VpNmJvYU1NZ0xxTU1WMFhQVy9FdmN6blE9");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDEyMzI3QDMxMzgyZTM0MmUzMGhGNXd3aUFreUk5NGFzRUVpOWlMRzlrbWI5SENEUTdsSFA4QVFxU01DaUk9");


            // DependencyService.Register<MockDataStore>();
            MainPage = new Login();
    
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
