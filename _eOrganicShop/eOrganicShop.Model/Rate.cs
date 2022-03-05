using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model
{
    public class Rate
    {
        public int RateID { get; set; }
        public int KorisnikID { get; set; }
        public int ProizvodID { get; set; }
        public int Rating { get; set; }
    }
}
