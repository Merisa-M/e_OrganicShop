using eOgranicShop.Mobile.Helpers;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eOgranicShop.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lozinka : ContentPage
    {
        private readonly APIService korisnikService = new APIService("Korisnici");

        public Lozinka()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");


                if (TrenutnaLozinka.Text != APIService.Password)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Pogresna lozinka.", "Try again");
                    return;
                }

                if (PotvrdiLozinku.Text != NovaLozinka.Text)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Lozinke se ne poklapaju.", "Try again");
                    return;
                }

                if (NovaLozinka.Text.Length < 8)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Lozinka mora imati najmanje 8 karaktera.", "Try again");
                    return;
                }

                if (!hasNumber.IsMatch(NovaLozinka.Text) || !hasUpperChar.IsMatch(NovaLozinka.Text) || !hasMinimum8Chars.IsMatch(NovaLozinka.Text))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password must contain number, uppercase, lowercase and minimum 8 characters!", "Try again");
                    return;
                }


                if (!hasNumber.IsMatch(PotvrdiLozinku.Text) || !hasUpperChar.IsMatch(PotvrdiLozinku.Text) || !hasMinimum8Chars.IsMatch(PotvrdiLozinku.Text))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password must contain number, uppercase, lowercase and minimum 8 characters!", "Try again");
                    return;
                }

                await korisnikService.Update<Korisnici>(SignIn.Korisnik.KorisnikID, new KorisnikUpsertRequest
                {
                    Ime = SignIn.Korisnik.Ime,
                    Prezime = SignIn.Korisnik.Prezime,
                    Email = SignIn.Korisnik.Email,
                    Telefon = SignIn.Korisnik.Telefon,
                    KorisnickoIme = SignIn.Korisnik.KorisnickoIme,
                    Password = NovaLozinka.Text,
                    PasswordConfirmation = PotvrdiLozinku.Text
                });

                await Application.Current.MainPage.DisplayAlert("Success", "Uspjesno spremljeno, ponovo se logirajte.", "OK");
                await Navigation.PushAsync(new Login());
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong.", "Try again");
            }
        }

    }
}