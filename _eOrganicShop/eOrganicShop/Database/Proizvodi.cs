using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class Proizvodi
    {
        public Proizvodi()
        {
            Review = new HashSet<Review>();
        }

        [Key]
        public int ProizvodID { get; set; }
        public string NazivProizvoda { get; set; }
        public int VrstaProizvodaID { get; set; }
        public string Opis { get; set; }
        public string Sifra { get; set; }
        public float Cijena { get; set; }
        public byte[] Slika { get; set; }
        public int KorisnikID { get; set; }
        public Korisnici Korisnik { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Favoriti> Favoriti { get; set; }
        public ICollection<Rate> Rate { get; set; }
        public virtual VrsteProizvoda VrstaProizvoda { get; set; }
    }
}
