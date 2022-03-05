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
    public partial class ProizvodiPage : ContentPage
    {
        private PretragaVM model = null;
        public ProizvodiPage()
        {
            InitializeComponent();
            BindingContext = model = new PretragaVM();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_SelectedProizvod(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Proizvodi;

            await Navigation.PushAsync(new ProizvodiDetalji(item));
        }
    }
}