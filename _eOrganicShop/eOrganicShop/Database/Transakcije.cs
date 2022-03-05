using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class Transakcije
    {
        [Key]
        public int TransakcijaID { get; set; }
        public int KorisnikID { get; set; }
        public Korisnici Korisnik { get; set; }
        public DateTime DatumTranskacije { get; set; }
        public float Cijena { get; set; }
        public string BrojNarudzbe { get; set; }
        public string KorisnickoIme { get; set; }
        public int NarudzbaID { get; set; }
        public Narudzba Narudzba { get; set; }
    }
}
