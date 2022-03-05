using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eOrganicShop.Model
{
    public class NarudzbaStavke
    {
        public int NarudzbaStavkeID { get; set; }
        public int NarudzbaId { get; set; }
        public int ProizvodId { get; set; }
        public Proizvodi Proizvod { get; set; }
        public Narudzba Narudzba { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal? Popust { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
    }
}
