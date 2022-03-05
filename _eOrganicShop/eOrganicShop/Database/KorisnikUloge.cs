using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class KorisnikUloge
    {
        [Key]
        public int KorisnikUlogeID { get; set; }
        public int KorisnikID { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public int UlogeID { get; set; }
        public virtual Uloge Uloge { get; set; }
    }
}
