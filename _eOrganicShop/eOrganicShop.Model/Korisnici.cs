using System;
using System.Collections.Generic;
using System.Text;
namespace eOrganicShop.Model
{
    public class Korisnici
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public byte[] Image { get; set; }
        public ICollection<KorisnikUloge> KorisnikUloge { get; set; }
        //  public virtual ICollection<Review> Review { get; set; }
    }
}
