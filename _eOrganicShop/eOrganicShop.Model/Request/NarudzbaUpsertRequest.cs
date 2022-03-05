using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class NarudzbaUpsertRequest
    {
        public int NarudzbaID { get; set; }

        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public float Iznos { get; set; }
        public int KorisnikID { get; set; }

        public List<NarudzbaStavkaUpsertRequest> stavke { get; set; } = new List<NarudzbaStavkaUpsertRequest>();
    }
}
