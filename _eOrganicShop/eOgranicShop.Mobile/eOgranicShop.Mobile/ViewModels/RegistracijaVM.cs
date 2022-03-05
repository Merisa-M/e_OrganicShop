using eOgranicShop.Mobile.Views;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eOgranicShop.Mobile.ViewModels
{
    public class RegistracijaVM : BaseViewModel
    {
        private readonly APIService userService = new APIService("Korisnici");
        string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }

        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetProperty(ref firstName, value); }
        }

        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value); }
        }

        string email;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        string phone;
        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

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

        string passwordConfirmation;
        public string PasswordConfirmation
        {
            get { return passwordConfirmation; }
            set { SetProperty(ref passwordConfirmation, value); }
        }
        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public RegistracijaVM()
        {
            RegisterCommand = new Command(async () => await Register());
            LoginCommand = new Command(() => LoginLoad());
        }
        public async Task Register()
        {
            try
            {
                KorisnikUpsertRequest request = null;
                bool req = true;
                if (Email == null || FirstName == null || LastName == null || Username == null || Password == null || PasswordConfirmation == null || Phone == null ||
                    Email == "" || FirstName == "" || LastName == "" || Username == "" || Password == "" || PasswordConfirmation == "" || Phone == "")
                {
                    await App.Current.MainPage.DisplayAlert("Information", "You have to fill all fields!", "OK");
                    req = false;
                }

                request = new KorisnikUpsertRequest()
                {
                    Ime = FirstName,
                    Prezime = LastName,
                    Email = Email,
                    Telefon = Phone,
                    KorisnickoIme = Username,
                    Password = Password,
                    PasswordConfirmation = PasswordConfirmation,
                    Uloge = new List<int> { 2 }
                };
                if (request != null)
                {
                    bool err = false;
                    bool isValid = Regex.IsMatch(Email, emailPattern); ;
                    var hasNumber = new Regex(@"[0-9]+");
                    var hasUpperChar = new Regex(@"[A-Z]+");
                    var hasMinimum8Chars = new Regex(@".{8,}");
                    if (!hasNumber.IsMatch(request.Password) || !hasUpperChar.IsMatch(request.Password) || !hasMinimum8Chars.IsMatch(request.Password))
                    {
                        await App.Current.MainPage.DisplayAlert("Information", "Lozinka mora da ima 8 karaktera sa malim, velikim slovima i brojevima!", "OK");
                        err = true;
                    }
                    if (request.Password != request.PasswordConfirmation)
                    {
                        await App.Current.MainPage.DisplayAlert("Information", "Lozinke se ne poklapaju!", "OK");
                        err = true;
                    }
                    if (!IsDigitsOnly(request.Telefon))
                    {
                        await App.Current.MainPage.DisplayAlert("Information", "Koristiti samo brojeve!", "OK");
                        err = true;
                    }
                    var users = await userService.Get<List<Korisnici>>(null);
                    foreach (var k in users)
                    {
                        if (k.KorisnickoIme == request.KorisnickoIme)
                        {
                            await App.Current.MainPage.DisplayAlert("Information", "Korisničko ime je zauzeto!", "OK");
                            err = true;
                            break;
                        }
                        else if (request.KorisnickoIme.Length < 3)
                        {
                            await App.Current.MainPage.DisplayAlert("Information", "Korisnicko ime treba da ima najmanje 3 karaktera!", "OK");
                            err = true;
                            break;
                        }
                    }

                    foreach (var k in users)
                    {
                        if (k.Email == request.Email)
                        {
                            await App.Current.MainPage.DisplayAlert("Information", "Email se već koristi!", "OK");
                            err = true;
                            break;
                        }
                    }
                    //if (!isValid)
                    //{
                    //    await App.Current.MainPage.DisplayAlert("Information", "Enter email in a valid format!", "OK");
                    //    err = true;
                    //}
                    if (err != true)
                    {
                        await userService.Login(request);
                        await Application.Current.MainPage.DisplayAlert("Upješno", "Vaša registracija je uspješna", "OK");
                        Application.Current.MainPage = new Login();
                    }
                }
            }
            catch
            {
                //await Application.Current.MainPage.DisplayAlert("Error", "An error has accured", "OK");
            }
        }
        void LoginLoad()
        {
            Application.Current.MainPage = new Login();
        }
    }

}
