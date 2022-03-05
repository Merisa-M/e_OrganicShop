using System;
using System.Collections.Generic;
using System.Text;

namespace eOgranicShop.Mobile.Models
{
    public enum MenuType
    {
        PreporuceniProizvodi,
        PretragaProizvoda,
        Favoriti,
        Korpa,
        Transakcije,
        MojRacun,
        Odjava
    };
    public class MenuItems
    {
        public MenuType ID { get; set; }
        public string Title { get; set; }
    }
    
}
