using eOgranicShop.Mobile.ViewModels;
using eOrganicShop.Model;
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
    public partial class KupljeniProizvodi : ContentPage
    {
        
        private KupljeniProizvodiVM model = null;

        public KupljeniProizvodi(Transakcije transakcije)
        {
            InitializeComponent();

            BindingContext = model = new KupljeniProizvodiVM(this.Navigation)
            {
                Narudzba = transakcije

            };


        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        public KupljeniProizvodi()
        {
            InitializeComponent();
        }
      

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Proizvodi;
            await Navigation.PushAsync(new KupljeniProizvodDetalji(item));
        }
    }
}