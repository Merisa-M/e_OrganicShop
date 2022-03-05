using Acr.UserDialogs;
using eOgranicShop.Mobile.Helpers;
using eOgranicShop.Mobile.Services;
using eOgranicShop.Mobile.ViewModels;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
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
    public partial class KorpaPage : ContentPage
    {
        private NarudzbaVM model = null;
        private APIService _service = new APIService("Narudzba");
        private APIService _serviceStavke = new APIService("NarudzbaStavke");

        public KorpaPage()
        {
            InitializeComponent();
            BindingContext = model = new NarudzbaVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init();

        }

        private async void Zakljuci_Clicked(object sender, EventArgs e)
        {
            if (model.Iznos == 0)
            {
                UserDialogs.Instance.Alert("Niste napravili niti jednu narudzbu!");
                return;
            }
            List<Narudzba> list = await _service.Get<List<Narudzba>>(null);
            int najveci = int.MinValue;
            foreach (var item in list)
            {

                if (item.NarudzbaID > najveci)
                {
                    najveci = item.NarudzbaID;
                }
            }
            int BrojNarudzbe = najveci + 1;


            string neki = BrojNarudzbeHelper.GenerisiBrojNarudzbe(BrojNarudzbe);


            NarudzbaUpsertRequest request = new NarudzbaUpsertRequest();

            request.BrojNarudzbe = neki;
            request.Datum = DateTime.Now;
            request.KorisnikID = SignIn.Korisnik.KorisnikID;
            await _service.Insert<Narudzba>(request);


            var narudzba = await _service.GetByBrojNarudzbe(neki);
          
            foreach (var item in model.NarudzbaList)
            {
                NarudzbaStavkaUpsertRequest stavka = new NarudzbaStavkaUpsertRequest();

                stavka.ProizvodID = item.Proizvodi.ProizvodID;
                stavka.Cijena = item.Proizvodi.Cijena;
                stavka.Kolicina = item.Kolicina;
                stavka.Popust = 0;
                stavka.NarudzbaID = narudzba.NarudzbaID;


                request.Iznos += stavka.Cijena * stavka.Kolicina;

                request.stavke.Add(stavka);
                await _serviceStavke.Insert<NarudzbaStavke>(stavka);
            }
            request.NarudzbaID = narudzba.NarudzbaID;
            await _service.Update<Narudzba>(narudzba.NarudzbaID, request);



            await DisplayAlert("Uspjeh", "Uspjesno ste napravili novu narudzbu", "OK");
            model.NarudzbaList.Clear();
            CartService.Cart.Clear();
            lblBrojArtikala.Text = "Broj artikala: 0";
            lblIznos.Text = "Iznos: 0 KM";

            await Navigation.PushAsync(new KupiProizvod(model.Iznos,narudzba.NarudzbaID));

        }
        private void Otkazi_Clicked(object sender, EventArgs e)
        {
            model.NarudzbaList.Clear();
            CartService.Cart.Clear();
            lblBrojArtikala.Text = "Broj artikala: 0";
            lblIznos.Text = "Iznos: 0 KM";

        }
    }
}