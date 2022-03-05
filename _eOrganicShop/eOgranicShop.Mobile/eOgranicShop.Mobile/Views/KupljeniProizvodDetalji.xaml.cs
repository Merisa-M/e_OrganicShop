using eOgranicShop.Mobile.Helpers;
using eOgranicShop.Mobile.ViewModels;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
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
    public partial class KupljeniProizvodDetalji : ContentPage
    {
        KupljeniProizvodDetaljiVM viewModel = null;
        private readonly APIService rateService = new APIService("Rate");
        public KupljeniProizvodDetalji(Proizvodi proizvod)
        {
            InitializeComponent();
            BindingContext = viewModel = new KupljeniProizvodDetaljiVM(proizvod, this.Navigation);
          
        } 
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.Init();         
        }

        private async void SfRating_ValueChanged(object sender, Syncfusion.SfRating.XForms.ValueEventArgs e)
        {
            int Rate = Convert.ToInt32(e.Value);
            var request = new RateUpsertRequest()
            {
                KorisnikID = SignIn.Korisnik.KorisnikID,
               ProizvodID = viewModel.Proizvodi.ProizvodID,
                Rating = Rate
            };

            if (viewModel.Rate == null)
            {
                viewModel.Rate = await rateService.Insert<Rate>(request);
            }
            else if (viewModel.Rate != null && viewModel.Rating == 0)
            {
                await rateService.Delete<Rate>(viewModel.Rate.RateID);
            }
            else
            {
                await rateService.Update<Rate>(viewModel.Rate.RateID, request);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var komentar = button?.BindingContext as Review;

            await viewModel.Delete(komentar);
        }
    }
}