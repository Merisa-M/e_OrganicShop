using eOgranicShop.Mobile.Helpers;
using eOrganicShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eOgranicShop.Mobile.ViewModels
{
    public class PreporuceniProizvodiVM : BaseViewModel
    {
        private readonly APIService recommendationService = new APIService("Recommendation");
        private readonly APIService proizvodiService = new APIService("Proizvodi");

        public ObservableCollection<Proizvodi> _preporuceniProizvodi { get; set; } = new ObservableCollection<Proizvodi>();

        public ICommand InitCommand { get; set; }
        public PreporuceniProizvodiVM()
        {
            InitCommand = new Command(async () => await Init());

        }
        private Proizvodi _proizvod;
        public Proizvodi Proizvodi
        {
            get { return _proizvod; }
            set { SetProperty(ref _proizvod, value); }
        }
        private string _nazivProizvoda;
        public string nazivProizvoda
        {
            get { return _nazivProizvoda; }
            set { SetProperty(ref _nazivProizvoda, value); }
        }
        public async Task Init()
        {
            var korisnikID = SignIn.Korisnik.KorisnikID;
            _preporuceniProizvodi.Clear();
            var preporuceniProizvodi = await recommendationService.GetPreporuceneProizvode(korisnikID);

            foreach (var p in preporuceniProizvodi)
            {
                    _preporuceniProizvodi.Add(p);
            }
        }
    }
}
