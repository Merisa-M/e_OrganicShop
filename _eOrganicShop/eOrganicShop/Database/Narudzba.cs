using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class Narudzba
    {
        public Narudzba()
        {
            NarudzbaStavke = new HashSet<NarudzbaStavke>();
        }
        public int NarudzbaID { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public float Iznos { get; set; }
        public int KorisnikID { get; set; }

        public Korisnici Korisnik { get; set; }

        public ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }
    }
}
