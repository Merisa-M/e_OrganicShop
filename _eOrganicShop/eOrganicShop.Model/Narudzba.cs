using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model
{
    public class Narudzba
    {
        public int NarudzbaID { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public int KorisnikID { get; set; }
        public decimal Iznos { get; set; }
        public string KorisnikKorisnickoIme { get; set; }
        public ICollection<NarudzbaStavke> NarudzbaStavke { get; set; }

    }
}
