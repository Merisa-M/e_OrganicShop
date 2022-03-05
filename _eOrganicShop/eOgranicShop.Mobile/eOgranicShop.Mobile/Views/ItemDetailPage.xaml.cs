using eOgranicShop.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace eOgranicShop.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}