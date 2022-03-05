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
    public partial class TransakcijePage : ContentPage
    {
        private TransakcijeVM model = null;
        public TransakcijePage()
        {
            InitializeComponent();
            BindingContext = model = new TransakcijeVM();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void Proizvod_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var item = e.SelectedItem as Narudzba;
            //await Navigation.PushAsync(new RateProizvod(item));
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Transakcije;
            await Navigation.PushAsync(new KupljeniProizvodi(item));
        }
    }
}