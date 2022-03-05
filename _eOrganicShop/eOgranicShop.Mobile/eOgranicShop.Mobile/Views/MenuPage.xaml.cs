using eOgranicShop.Mobile.Models;
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
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<MenuItems> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            menuItems = new List<MenuItems>
            {
                new MenuItems {ID = MenuType.PreporuceniProizvodi, Title="Preporučeni proizvodi"},
                new MenuItems {ID = MenuType.PretragaProizvoda, Title="Proizvodi"},
                new MenuItems {ID = MenuType.Favoriti, Title="Omiljeni proizvodi"},
                new MenuItems {ID = MenuType.Korpa, Title="Korpa"},
                new MenuItems {ID = MenuType.Transakcije, Title="Transakcije"},
                new MenuItems {ID = MenuType.MojRacun, Title="Moj račun" },
                new MenuItems {ID = MenuType.Odjava, Title="Logout" }
            };
            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var ID = (int)((MenuItems)e.SelectedItem).ID;
                await RootPage.NavigateFromMenu(ID);
            };
        }
    }
}