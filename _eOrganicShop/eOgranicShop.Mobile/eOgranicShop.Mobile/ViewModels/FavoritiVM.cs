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
    public class FavoritiVM : BaseViewModel
    {
        private readonly APIService favoritiService = new APIService("Favoriti");
        private readonly APIService proizvodiService = new APIService("Proizvodi");

        public ObservableCollection<Proizvodi> FavoritiList { get; set; } = new ObservableCollection<Proizvodi>();

        public ICommand InitCommand { get; set; }
        public FavoritiVM()
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
            List<Favoriti> favoritiList = null;
            favoritiList = await favoritiService.Get<List<Favoriti>>(new FavoritiSearchRequest { KorisnikID = SignIn.Korisnik.KorisnikID });
            FavoritiList.Clear();
            var proizvodi = await proizvodiService.Get<List<Proizvodi>>(null);

            foreach (var x in proizvodi)
            {
                if (favoritiList.Select(i => i.ProizvodID).Contains(x.ProizvodID))
                {
                    FavoritiList.Add(x);
                }
            }
        }
    }
}
