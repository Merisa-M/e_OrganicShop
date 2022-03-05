using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class Korisnici
    {
        [Key]
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<KorisnikUloge> KorisnikUloge { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Rate> Rate { get; set; }

    }
}
