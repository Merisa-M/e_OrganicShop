using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public DateTime Datum { get; set; }
        public string Komentar { get; set; }
        public int KorisnikID { get; set; }
        public int ProizvodID { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public virtual Proizvodi Proizvod { get; set; }
    }
}
