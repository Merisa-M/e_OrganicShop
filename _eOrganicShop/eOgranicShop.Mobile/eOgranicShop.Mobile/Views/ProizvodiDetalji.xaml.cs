using eOgranicShop.Mobile.ViewModels;
using eOrganicShop.Model;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eOrganicShop.Model.Request;
using Acr.UserDialogs;
using eOgranicShop.Mobile.Helpers;

namespace eOgranicShop.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProizvodiDetalji : ContentPage
    {
		DetaljiVM viewModel = null;
		private readonly APIService _narudzbe = new APIService("Narudzba");
		private readonly APIService _stavke = new APIService("NarudzbaStavka");
        private readonly APIService _favoriti = new APIService("Favoriti");
        private readonly APIService _korisnici = new APIService("Korisnici");


        Proizvodi _proizvod;
		public ProizvodiDetalji(Proizvodi proizvod)
		{
			InitializeComponent();
            _proizvod = proizvod;
            BindingContext = viewModel = new DetaljiVM()
            {
				Proizvodi= proizvod
            };
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
			await viewModel.Init();

            var request = new FavoritiSearchRequest
            {
                ProizvodID = _proizvod.ProizvodID,
                KorisnikID = SignIn.Korisnik.KorisnikID
            };
            var favorite = await _favoriti.Get<List<Favoriti>>(request);
            if (favorite.Count() != 0)
            {
                btnDodajUFavorite.IsVisible = false;
                btnIzbrisiIzFavorita.IsVisible = true;
            }
            else
            {
                btnIzbrisiIzFavorita.IsVisible = false;
                btnDodajUFavorite.IsVisible = true;
            }
        }

        private async void zatvori_Clicked(object sender, EventArgs e)
        {

            await PopupNavigation.Instance.PopAsync(true);

             
        }

		private async void Dodaj_Clicked(object sender, EventArgs e)
		{
			var proID = ((Button)sender).BindingContext;
			int proizvodID = int.Parse(proID.ToString());
			if (Global.NarudzbaID == 0)
			{
				NarudzbaUpsertRequest query = new NarudzbaUpsertRequest();
				query.KorisnikID = Global.LogiraniKorisnikID;
				
				Narudzba entity = null;
				entity = await _narudzbe.Insert<Narudzba>(query);

			}
			NarudzbaStavkaUpsertRequest stavka = new NarudzbaStavkaUpsertRequest();
			stavka.ProizvodID = proizvodID;
			stavka.Kolicina = 1;
			stavka.NarudzbaID = Global.NarudzbaID;
			NarudzbaStavke entityStavka = null;
			entityStavka = await _stavke.Insert<NarudzbaStavke>(stavka);
			var stringBuilder = new StringBuilder();
			await Application.Current.MainPage.DisplayAlert("Proizvod je dodan u košaricu!", stringBuilder.ToString(), "OK");


		}

        private async void btnDodajUFavorite_Clicked(object sender, EventArgs e)
        {
            var request = new FavoritiSearchRequest
            {
                ProizvodID = _proizvod.ProizvodID,
                KorisnikID = SignIn.Korisnik.KorisnikID
            };
            await _korisnici.InsertLikedProizvodi(request.KorisnikID, request.ProizvodID);
            var proizvod = viewModel.Proizvodi;
            await Navigation.PushAsync(new ProizvodiDetalji(proizvod));
        }

        private async void btnIzbrisiIzFavorita_Clicked(object sender, EventArgs e)
        {
            var request = new FavoritiSearchRequest
            {
                ProizvodID = _proizvod.ProizvodID,
                KorisnikID = SignIn.Korisnik.KorisnikID
            };
            await _korisnici.DeleteLikedProizvod(request.KorisnikID, request.ProizvodID);
            var proizvod = viewModel.Proizvodi;
            await Navigation.PushAsync(new ProizvodiDetalji(proizvod));
        }
    }
}