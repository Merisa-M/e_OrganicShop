using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class Kupovine
    {
        [Key]
        public int KupovinaID { get; set; }
        public int KorisnikID { get; set; }
        public int NarudzbaID { get; set; }
        public DateTime DatumKupovine { get; set; }
        public float Cijena { get; set; }
        public string KorisnickoIme { get; set; }
        public string NazivProizovda { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public virtual Narudzba Narudzba { get; set; }
        public string StripeId { get; set; }
    }
}
