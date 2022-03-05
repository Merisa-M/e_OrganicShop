using eOgranicShop.Mobile.ViewModels;
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
    public partial class Registracija : ContentPage
    {
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
        public Registracija()
        {
            InitializeComponent();
           
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ErrorLabel_Ime.IsVisible = false;
            ErrorLabel_Prezime.IsVisible = false;
            ErrorLabel_KorisnickoIme.IsVisible = false;
            ErrorLabel_Email.IsVisible = false;
            ErrorLabel_Telefon.IsVisible = false;
            ErrorLabel_Lozinka.IsVisible = false;
            ErrorLabel_PasswordConfirmation.IsVisible = false;
        }
        private void ime_changed(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Ime.Text))
            {
                ErrorLabel_Ime.IsVisible = true;
                ErrorLabel_Ime.Text = "Obavezno polje!";
            }
            else
            {
                ErrorLabel_Ime.IsVisible = false;
            }
        }

        private void ime_unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Ime.Text))
            {
                ErrorLabel_Ime.IsVisible = true;
                ErrorLabel_Ime.Text = "Polje je obavezno!";
            }
            else
            {
                ErrorLabel_Ime.IsVisible = false;

            }
        }
        private void prezime_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Prezime.Text))
            {
                ErrorLabel_Prezime.IsVisible = true;
                ErrorLabel_Prezime.Text = "Polje je obavezno";
            }
            else
            {
                ErrorLabel_Prezime.IsVisible = false;


            }

        }
        private void prezime_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Prezime.Text))
            {
                ErrorLabel_Prezime.IsVisible = true;
                ErrorLabel_Prezime.Text = "Polje je obavezno";
            }
            else
            {


                ErrorLabel_Prezime.IsVisible = false;

            }


        }

        private void korisnickoime_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(KorisnickoIme.Text))
            {
                ErrorLabel_KorisnickoIme.IsVisible = true;
                ErrorLabel_KorisnickoIme.Text = "Polje je obavezno";
            }
            else
            {
                ErrorLabel_KorisnickoIme.IsVisible = false;


            }

        }
        private void korisnickoime_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(KorisnickoIme.Text))
            {
                ErrorLabel_KorisnickoIme.IsVisible = true;
                ErrorLabel_KorisnickoIme.Text = "Polje je obavezno";
            }
            else
            {
                ErrorLabel_KorisnickoIme.IsVisible = false;

            }


        }

        private void email_unfocused(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "Polje je obavezno";
            }
            else
            {
                ErrorLabel_Email.IsVisible = false;


            }

        }
        private void email_changed(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                ErrorLabel_Email.IsVisible = true;
                ErrorLabel_Email.Text = "Polje je obavezno";
            }
            else
            {
                ErrorLabel_Email.IsVisible = false;

            }


        }

        private void telefon_unfocused(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Telefon.Text))
            {
                ErrorLabel_Telefon.IsVisible = true;
                ErrorLabel_Telefon.Text = "Polje je obavezno!";
            }
            else
            {
                ErrorLabel_Telefon.IsVisible = false;
            }
            if (Telefon.Text != null)
            {
                if (IsDigitsOnly(Telefon.Text) == false)
                {
                    ErrorLabel_Telefon.IsVisible = true;
                    ErrorLabel_Telefon.Text = "Ne mozes koristiti brojeve!";
                }
                else
                {
                    ErrorLabel_Telefon.IsVisible = false;
                }
            }
        }
        private void telefon_changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Telefon.Text))
            {
                ErrorLabel_Telefon.IsVisible = true;
                ErrorLabel_Telefon.Text = "Polje je obavezno!";
            }
            else
            {
                ErrorLabel_Telefon.IsVisible = false;
            }
            if (Telefon.Text != null)
            {
                if (IsDigitsOnly(Telefon.Text) == false)
                {
                    ErrorLabel_Telefon.IsVisible = true;
                    ErrorLabel_Telefon.Text = "Koristite samo brojeve!";
                }
                else
                {
                    ErrorLabel_Telefon.IsVisible = false;
                }
            }
        }
        private void lozinka_unfocused(object sender, System.EventArgs e)
        {


            if (string.IsNullOrEmpty(Lozinka.Text))
            {
                ErrorLabel_Lozinka.IsVisible = true;
                ErrorLabel_Lozinka.Text = "Lozinka ne moze biti prazno polje";
            }
            else
            {
                ErrorLabel_Lozinka.IsVisible = false;
            }


        }
        private void lozinka_changed(object sender, System.EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            if (string.IsNullOrEmpty(Lozinka.Text))
            {
                ErrorLabel_Lozinka.IsVisible = true;
                ErrorLabel_Lozinka.Text = "Lozinka ne moze biti prazno polje";
            }
            else if (!hasNumber.IsMatch(Lozinka.Text) || !hasUpperChar.IsMatch(Lozinka.Text) || !hasMinimum8Chars.IsMatch(Lozinka.Text))
            {


                ErrorLabel_Lozinka.IsVisible = true;
                ErrorLabel_Lozinka.Text = "Lozinka mora imati brojeve,velika slova i minimum 8 karaktera";
            }
            else
            {
                ErrorLabel_Lozinka.IsVisible = false;
            }


        }

        private void passwordconfirmation_unfocused(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            if (string.IsNullOrEmpty(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Polje je obavezno!";
            }
            else if (!hasNumber.IsMatch(PasswordConfirmation.Text) || !hasUpperChar.IsMatch(PasswordConfirmation.Text) || !hasMinimum8Chars.IsMatch(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Lozinka mora da ima  brojeve, veliko slovo, mala slova i minimum 8 karaktera!";
            }
            else
            {
                ErrorLabel_PasswordConfirmation.IsVisible = false;
            }

        }
        private void passwordconfirmation_changed(object sender, EventArgs e)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            if (string.IsNullOrEmpty(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Polje je obavezno!";
            }
            else if (!hasNumber.IsMatch(PasswordConfirmation.Text) || !hasUpperChar.IsMatch(PasswordConfirmation.Text) || !hasMinimum8Chars.IsMatch(PasswordConfirmation.Text))
            {
                ErrorLabel_PasswordConfirmation.IsVisible = true;
                ErrorLabel_PasswordConfirmation.Text = "Lozinka mora da ima brojeve, veliko slovo, mala slova i minimum 8 karaktera!";
            }
            else
            {
                ErrorLabel_PasswordConfirmation.IsVisible = false;
            }
        }

    }
}