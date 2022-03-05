using Acr.UserDialogs;
using eOgranicShop.Mobile.Models;
using eOgranicShop.Mobile.Services;
using eOgranicShop.Mobile.Views;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eOgranicShop.Mobile.ViewModels
{
    public class DetaljiVM:BaseViewModel
    {

        private readonly APIService komentariService = new APIService("Review");
        private readonly APIService korisniciService = new APIService("Korisnici");
        private readonly APIService proizvodiService = new APIService("Proizvodi");

        public ObservableCollection<Review> KomentariList { get; set; } = new ObservableCollection<Review>();
    
        public DetaljiVM()
        {
            KolicinaIncrementCommand = new Command(() => Kolicina += 1);
            KolicinaDecrementCommand = new Command(() => Kolicina -= 1);

            KupiCommand = new Command(Kupi);
            NaruciCommand = new Command(async () => await Naruci());
            InitCommand = new Command(async () => await Init());

        }
        public eOrganicShop.Model.Proizvodi Proizvodi { get; set; }

        int _kolicina = 0;
        public int Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); }
        }
        public ICommand NaruciCommand { get; set; }
        public ICommand KolicinaIncrementCommand { get; set; }
        public ICommand KolicinaDecrementCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand KupiCommand { get; set; }

        private float rating;
        public float Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }

        private void Kupi()
        {
            if (CartService.Cart.ContainsKey(Proizvodi.ProizvodID))
            {
                CartService.Cart.Remove(Proizvodi.ProizvodID);
            }

            CartService.Cart.Add(Proizvodi.ProizvodID, this);
        }


        public float _cijena = 0;
        string _komentar = null;
        public string Komentar
        {
            get { return _komentar; }
            set
            {
                SetProperty(ref _komentar, value);
            }
        }

        public float Cijena
        {
            get { return _cijena; }
            set { SetProperty(ref _cijena, value); }
        }
        private readonly INavigation Navigation;

        private async Task Naruci()
        {
            if (Kolicina == 0)
            {
                UserDialogs.Instance.Alert("Molim vas, unesite količinu!");
                return;
            }

            if (CartService.Cart.ContainsKey(Proizvodi.ProizvodID))
            {
                
                foreach (var item in CartService.Cart.Values)
                {

                    if (item.Proizvodi.ProizvodID == Proizvodi.ProizvodID)
                    {

                        if (item.Kolicina == Kolicina)
                        {
                            item.Kolicina += 1;
                            item.Cijena = Proizvodi.Cijena * item.Kolicina;
                            Cijena = item.Cijena;
                            Kolicina = item.Kolicina;
                        }
                        else
                        {

                            //Kolicina += 1;
                            Cijena = Proizvodi.Cijena * Kolicina;
                            item.Kolicina = Kolicina;
                            item.Cijena = Cijena;

                        }
                    }

                }
            }
            else
            {
                CartService.Cart.Add(Proizvodi.ProizvodID, this);

            }
            await Application.Current.MainPage.DisplayAlert("Uspjeh", "Uspješno ste dodali u korpu!", "OK");

        }
        //public async Task InitKomentar()
        //{
        //    KomentariList.Clear();
        //    try
        //    {
        //        var comments = await komentariService.Get<List<Review>>(null);
        //        foreach (var comment in comments)
        //        {
        //            KomentariList.Add(comment);
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
        public async Task Init()
        {
            Rating = await proizvodiService.GetProsjekRating<float>(Proizvodi.ProizvodID);

            KomentariList.Clear();
            List<Review> komentari = await komentariService.Get<List<Review>>(null);

            foreach (var k in komentari)
            {

                if (k.ProizvodID == Proizvodi.ProizvodID)
                {
                    k.Korisnik = await korisniciService.GetById<Korisnici>(k.KorisnikID);
                    KomentariList.Add(k);

                }
            }
           

        }
    }
}
