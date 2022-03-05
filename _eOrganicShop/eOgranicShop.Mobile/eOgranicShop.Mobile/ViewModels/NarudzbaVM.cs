using eOgranicShop.Mobile.Services;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using Rg.Plugins.Popup.Services;
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
    public class NarudzbaVM:BaseViewModel
    {
        public ObservableCollection<DetaljiVM> NarudzbaList { get; set; } = new ObservableCollection<DetaljiVM>();


        decimal _brojproizvoda = 0;

        public decimal BrojProizvoda
        {
            get { return _brojproizvoda; }
            set { SetProperty(ref _brojproizvoda, value); }
        }
        float _iznos = 0;

        public float Iznos
        {
            get { return _iznos; }
            set { SetProperty(ref _iznos, value); }
        }

        public void Init()
        {


            foreach (var item in CartService.Cart.Values)
            {

                NarudzbaList.Add(item);
            }
            Iznos = 0;
            foreach (var item in NarudzbaList)
            {

                Iznos += item.Kolicina * item.Proizvodi.Cijena;
            }

            BrojProizvoda = NarudzbaList.Count();



            CartService.Cart.Clear();

        }

    }
}
