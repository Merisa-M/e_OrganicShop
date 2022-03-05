using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class Rate
    {
        [Key]
        public int RateID { get; set; }
        public int KorisnikID { get; set; }
        public int ProizvodID { get; set; }
        public int Rating { get; set; }
        public virtual Proizvodi Proizvod { get; set; }
        public virtual Korisnici Korisnik { get; set; }
    }
}
