using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class Favoriti
    {
        public int KorisnikID { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public int ProizvodID { get; set; }
        public virtual Proizvodi Proizvod { get; set; }
    }
}
