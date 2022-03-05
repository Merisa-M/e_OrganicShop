using eOgranicShop.Mobile.Helpers;
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
    public class ProizvodiPretragaVM: BaseViewModel
    {
        private readonly APIService proizvodService = new APIService("Proizvodi");
        private readonly APIService vrsteService = new APIService("VrsteProizvoda");

        public ObservableCollection<ProizvodiVM> proizvodiList { get; set; } = new ObservableCollection<ProizvodiVM>();
        public ObservableCollection<VrsteProizvoda> vrsteList { get; set; } = new ObservableCollection<VrsteProizvoda>();

        public ICommand InitCommand { get; set; }

        readonly Korisnici korisnik = SignIn.Korisnik;

        public ProizvodiPretragaVM()
        {
           // InitCommand = new Command(async () => await Init(korisnik));
            
        }
        VrsteProizvoda _selectedVrsta = null;
        public VrsteProizvoda SelectedVrsta
        {
            get { return _selectedVrsta; }
            set
            {
                SetProperty(ref _selectedVrsta, value);
                if (value != null)
                    InitCommand.Execute(null);

            }
        }
        
        

    }
}
