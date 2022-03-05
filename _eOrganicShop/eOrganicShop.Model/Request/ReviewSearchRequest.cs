using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class ReviewSearchRequest
    {
        public int KorisnikID { get; set; }
        public int ProizvodID { get; set; }
        public string Komentar { get; set; }
        public DateTime Datum { get; set; }

    }
}
