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
    public class PretragaVM:BaseViewModel
    {
        private readonly APIService proizvodService = new APIService("Proizvodi"); 
        private readonly APIService _vrsteProizvodaService = new APIService("VrsteProizvoda");
        public ObservableCollection<Proizvodi> proizvodList { get; set; } = new ObservableCollection<Proizvodi>();
        public ObservableCollection<VrsteProizvoda> vrsteList { get; set; } = new ObservableCollection<VrsteProizvoda>();
        VrsteProizvoda _selectedVrstaProizvoda = null;
        public VrsteProizvoda SelectedVrstaProizvoda
        {
            get { return _selectedVrstaProizvoda; }
            set
            {
                SetProperty(ref _selectedVrstaProizvoda, value);
                if (value != null)
                {
                    SearchProizvod.Execute(null);
                }

            }
        }

        public ICommand SearchProizvod { get; set; }

        public PretragaVM()
        {
            SearchProizvod = new Command(async (object query) => await Search(query));
        }
        private async Task Search(object query)
        {
            var request = new ProizvodiSearchRequest()
            {
                 NazivProizvoda= query as string
            };
            await Init();
        }
        public async Task Init()
        {

            if (vrsteList.Count == 0)
            {
                var vrsteProizvodaList = await _vrsteProizvodaService.Get<List<VrsteProizvoda>>(null);

                foreach (var vrsteProizvoda in vrsteProizvodaList)
                {
                    vrsteList.Add(vrsteProizvoda);
                }
            }
            if (SelectedVrstaProizvoda != null)
            {
                ProizvodiSearchRequest search = new ProizvodiSearchRequest();
                search.VrsteProizvodaID = SelectedVrstaProizvoda.VrsteProizvodaID;
                var proizvodi = await proizvodService.Get<List<Proizvodi>>(search);
                proizvodList.Clear();
                foreach (var proizvod in proizvodi)
                    {
                        proizvodList.Add(proizvod);

                    }
            }

        }
      
    }
}
