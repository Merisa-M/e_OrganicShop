using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class ProizvodiSearchRequest
    {
        public int KorisnikID { get; set; }
        public int? VrsteProizvodaID { get; set; }
        public string NazivProizvoda { get; set; }

    }
}
