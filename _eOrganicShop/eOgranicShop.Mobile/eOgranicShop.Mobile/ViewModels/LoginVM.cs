using eOgranicShop.Mobile.Helpers;
using eOgranicShop.Mobile.Views;
using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eOgranicShop.Mobile.ViewModels
{
    public class LoginVM: BaseViewModel
    {
        private readonly APIService korisnikService = new APIService("Korisnici");

        string username;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginVM()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(() => RegisterLoad());

        }
        void RegisterLoad()
        {
            Application.Current.MainPage = new Registracija();
        }
        private async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            var request = new UserAuthenticationRequest()
            {
                Username = APIService.Username,
                Password = APIService.Password
            };

            var korisnik = await korisnikService.Authenticate(request);

            if (korisnik != null)
            {
                Application.Current.MainPage = new MainPage();
                SignIn.Korisnik = korisnik;


            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Enter a valid Username and Password!", "OK");
            }
        }
    }
}
