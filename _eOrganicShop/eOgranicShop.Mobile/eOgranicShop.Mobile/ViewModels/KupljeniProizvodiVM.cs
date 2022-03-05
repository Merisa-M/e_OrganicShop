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
    public class KupljeniProizvodiVM : BaseViewModel
    {

        private readonly APIService komentariService = new APIService("Rate");
        private readonly APIService narudzbaStavkeService = new APIService("NarudzbaStavke");

        private readonly APIService korisniciService = new APIService("Proizvodi");
        private readonly APIService narudzbaService = new APIService("Narudzba");


        public ObservableCollection<Proizvodi> kupljeniProizvodiList { get; set; } = new ObservableCollection<Proizvodi>();


        private readonly INavigation Navigation;

        private Transakcije _narudzba;   private string _nazivProizvoda;
        public string nazivProizvoda
        {
            get { return _nazivProizvoda; }
            set { SetProperty(ref _nazivProizvoda, value); }
        }
        public Transakcije Narudzba
        {
            get { return _narudzba; }
            set { SetProperty(ref _narudzba, value); }
        }
     

        public KupljeniProizvodiVM(INavigation nav)
        { 
            this.Navigation = nav;
            InitCommand = new Command(async () => await Init());
        }
        public KupljeniProizvodiVM()
        {
            InitCommand = new Command(async () => await Init());

        }
        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var narudzba = await narudzbaService.GetById<Narudzba>(Narudzba.NarudzbaID);
            var req = new NarudzbeStavkeSearchRequest { NarudzbaId = narudzba.NarudzbaID };
            var listaNarudzbeStavke = await narudzbaStavkeService.Get<List<NarudzbaStavke>>(req);

            if (kupljeniProizvodiList.Count > 0)
                kupljeniProizvodiList.Clear();
            foreach (var stavke in listaNarudzbeStavke)
            {
                nazivProizvoda = stavke.Proizvod.NazivProizvoda;
                kupljeniProizvodiList.Add(stavke.Proizvod);
            }
        }
    }   
}

        