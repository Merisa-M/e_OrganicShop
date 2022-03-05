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
    public partial class FavoritiPage : ContentPage
    {
        private FavoritiVM model = null;
        public FavoritiPage()
        {
            InitializeComponent();
            BindingContext = model = new FavoritiVM();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var proizvod = e.SelectedItem as Proizvodi;
            await Navigation.PushAsync(new ProizvodiDetalji(proizvod));
        }
    }
}