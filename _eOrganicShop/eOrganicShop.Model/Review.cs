using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string Komentar { get; set; }
        public DateTime Datum { get; set; }
        public Korisnici Korisnik { get; set; }

        public int KorisnikID { get; set; }
        public int ProizvodID { get; set; }

    }
}
