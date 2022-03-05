using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model
{
    public class Transakcije
    {
        public int TransakcijaID { get; set; }
        public int KorisnikID { get; set; }
        public Model.Korisnici Korisnik { get; set; }
        public int ProizvodID { get; set; }
        public Model.Proizvodi Proizvod { get; set; }

        public int NarudzbaID { get; set; }
        public Model.Narudzba Narudzba { get; set; }
        public string BrojNarudzbe { get; set; }
                      
        public DateTime DatumTranskacije { get; set; }
        public string DatumTransakcijeString { get; set; }

        public float Cijena { get; set; }
        public string KorisnickoIme { get; set; }
    }
}
