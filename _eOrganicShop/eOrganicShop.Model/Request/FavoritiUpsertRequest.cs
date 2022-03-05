using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class FavoritiUpsertRequest
    {
        public int KorisnikID { get; set; }
        public int ProizvodID { get; set; }
    }
}
