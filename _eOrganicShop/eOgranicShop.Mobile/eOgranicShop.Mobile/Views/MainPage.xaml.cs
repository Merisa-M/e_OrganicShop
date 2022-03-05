using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eOgranicShop.Mobile.Models;

namespace eOgranicShop.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
        }
        public async Task NavigateFromMenu(int ID)
        {
            if (!MenuPages.ContainsKey(ID))
            {
                switch (ID)
                {
                    case (int)MenuType.PreporuceniProizvodi:
                        MenuPages.Add(ID, new NavigationPage(new PreporuceniProizvodiPage()));
                        break;
                    case (int)MenuType.PretragaProizvoda:
                        MenuPages.Add(ID, new NavigationPage(new ProizvodiPage()));
                        break;
                    case (int)MenuType.Favoriti:
                        MenuPages.Add(ID, new NavigationPage(new FavoritiPage()));
                        break;
                    case (int)MenuType.Korpa:
                        MenuPages.Add(ID, new NavigationPage(new KorpaPage()));
                        break;
                    case (int)MenuType.Transakcije:
                        MenuPages.Add(ID, new NavigationPage(new TransakcijePage()));
                        break;
                    case (int)MenuType.MojRacun:
                        MenuPages.Add(ID, new NavigationPage(new MojRacun()));
                        break;
                    case (int)MenuType.Odjava:
                        MenuPages.Add(ID, new NavigationPage(new Loguout()));
                        break;
                }
                
            }
            var newPage = MenuPages[ID];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }


        }
    }
}