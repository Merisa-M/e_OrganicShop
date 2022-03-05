using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model
{
    public class KorisnikUloge
    {
        public int KorisnikUlogeID { get; set; }
        public int KorisnikID { get; set; }
        public int UlogeID { get; set; }
        public Uloge Uloge { get; set; }
    }
}
