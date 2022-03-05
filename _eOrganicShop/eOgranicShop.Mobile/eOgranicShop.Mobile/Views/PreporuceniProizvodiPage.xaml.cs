using eOgranicShop.Mobile.Helpers;
using eOgranicShop.Mobile.ViewModels;
using eOrganicShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eOgranicShop.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreporuceniProizvodiPage : ContentPage
    {
        private readonly APIService recommendationService = new APIService("Recommendation");
        private PreporuceniProizvodiVM model = null;


        public PreporuceniProizvodiPage()
        {
            InitializeComponent();
            BindingContext = model = new PreporuceniProizvodiVM();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            int korisnikID = SignIn.Korisnik.KorisnikID;
            var preporuceniProizvodi = await recommendationService.GetPreporuceneProizvode(korisnikID);

            if (preporuceniProizvodi.Count < 1)
            {
                bezOcjene.IsVisible = true;
                Preporuka.IsVisible = false;
                ProizvodiZaVas.IsVisible = false;
            }
            else
            {
                bezOcjene.IsVisible = false;
                ProizvodiZaVas.IsVisible = true;
                Preporuka.IsVisible = true;
            }
        }

        private async void Preporuka_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var proizvod = e.SelectedItem as Proizvodi;
            await Navigation.PushAsync(new ProizvodiDetalji(proizvod));
        }
    }
}