using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class TransakcijeSearchRequest
    {
        public int KorisnikID { get; set; }
        public int NarudzbaID { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string BrojNarudzbe { get; set; }
                    

    }
}
