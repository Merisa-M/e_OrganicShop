using eOrganicShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOgranicShop.Mobile.Helpers
{
    public class LikeHelper
    {
        private readonly APIService korisnikService = new APIService("Korisnici");
        public static List<Proizvodi> FavProizvodi { get; set; }


        public LikeHelper()
        {
            Init();
        }
        private async Task Init()
        {
            FavProizvodi = await korisnikService.GetLikedProizvodi(SignIn.Korisnik.KorisnikID, null);

        }
        public static bool Remove(Proizvodi item)
        {
            var itemToRemove = FavProizvodi.Where(i => i.ProizvodID == item.ProizvodID).FirstOrDefault();
            return FavProizvodi.Remove(itemToRemove);
        }

    }
}
