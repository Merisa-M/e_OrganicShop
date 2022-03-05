using eOgranicShop.Mobile.Helpers;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eOgranicShop.Mobile.ViewModels
{
    public class KupljeniProizvodDetaljiVM: BaseViewModel
    {
        private readonly APIService rateService = new APIService("Rate");
        private readonly APIService reviewService = new APIService("Review");
        private readonly APIService korisniciService = new APIService("Korisnici");
        public ObservableCollection<Review> komentarList { get; set; } = new ObservableCollection<Review>();


        public eOrganicShop.Model.Proizvodi Proizvodi { get; set; }
        public float _cijena = 0;
        private readonly INavigation Navigation;
        public KupljeniProizvodDetaljiVM(Proizvodi proizvodi)
        {
            Proizvodi = proizvodi;
            DeleteCommand = new Command<Review>(async (comment) => await Delete(comment));
            AddCommand = new Command(async () => await Add());
        }
        public KupljeniProizvodDetaljiVM()
        {
            InitCommand = new Command(async () => await Init());
            AddCommand = new Command(async () => await Add());
        }
        public KupljeniProizvodDetaljiVM(INavigation nav)
        {
            InitCommand = new Command(async () => await Init());
            this.Navigation = nav;
            DeleteCommand = new Command<Review>(async (comment) => await Delete(comment));
            AddCommand = new Command(async () => await Add());
        }
        public ICommand AddCommand { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        private Rate _rate;
        public Rate Rate
        {
            get { return _rate; }
            set { SetProperty(ref _rate, value); }
        }
        private decimal rating;
        public decimal Rating
        {
            get { return rating; }
            set { SetProperty(ref rating, value); }
        }
        public async void GetReview()
        {
            await SetProizvodRate(Proizvodi.ProizvodID);
            Rating = (decimal)(Rate != null ? Rate.Rating : 0);
        }
        //private Proizvodi proizvod;
        //public Proizvodi Proizvod
        //{
        //    get { return proizvod; }
        //    set { SetProperty(ref proizvod, value); }
        //}
        private async Task SetProizvodRate(int ProizvodID)
        {
            var request = new RateSearchRequest()
            {
                ProizvodID = ProizvodID,
                KorisnikID = SignIn.Korisnik.KorisnikID
            };

            var list = await rateService.Get<List<Rate>>(request);
            if (list != null)
                Rate = list.FirstOrDefault();
        }

        public float Cijena
        {
            get { return _cijena; }
            set { SetProperty(ref _cijena, value); }
        }
        int _kolicina = 0;

        public KupljeniProizvodDetaljiVM(Proizvodi proizvodi, INavigation navigation)
        {
            Proizvodi = proizvodi;
            GetReview();
            Navigation = navigation;
            AddCommand = new Command(async () => await Add());
        }

        public int Kolicina
        {
            get { return _kolicina; }
            set { SetProperty(ref _kolicina, value); }
        }
        string komentar = null;
        public string Komentar
        {
            get { return komentar; }
            set
            {
                SetProperty(ref komentar, value);
            }
        }
        public async Task Delete(Review c)
        {
            var ID = c.ReviewID;
            if (c.KorisnikID == SignIn.Korisnik.KorisnikID)
            {
                await reviewService.Remove(ID);
                await Init();
            }
        }
        public async Task Init()

        {
            komentarList.Clear();
            List<Review> komentari = await reviewService.Get<List<Review>>(null);

            foreach (var k in komentari)
            {

                if (k.ProizvodID == Proizvodi.ProizvodID)
                {
                    k.Korisnik = await korisniciService.GetById<Korisnici>(k.KorisnikID);
                    komentarList.Add(k);

                }
            }


        }
        public async Task Add()
        {
            ReviewUpsertRequest request = new ReviewUpsertRequest()
            {
                Datum = DateTime.Now,
                ProizvodID = Proizvodi.ProizvodID,
                KorisnikID = SignIn.Korisnik.KorisnikID,
                Komentar = komentar
            };

            await reviewService.Insert<Review>(request);

            komentarList.Clear();
            Komentar = null;
            await Init();

        }
    }
}
