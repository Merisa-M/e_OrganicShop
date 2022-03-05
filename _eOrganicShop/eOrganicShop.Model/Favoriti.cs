using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model
{
    public class Favoriti
    {
        public int KorisnikID { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public int ProizvodID { get; set; }
        public virtual Proizvodi Proizvod { get; set; }
    }
}
