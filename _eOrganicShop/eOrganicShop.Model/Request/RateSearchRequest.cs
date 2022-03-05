using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class RateSearchRequest
    {
        public int KorisnikID { get; set; }
        public int ProizvodID { get; set; }
        public int Rating { get; set; }
    }
}
