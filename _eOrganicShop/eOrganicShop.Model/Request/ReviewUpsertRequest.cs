using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class ReviewUpsertRequest
    {
        public int KorisnikID { get; set; }
        public int ProizvodID { get; set; }
        public string Komentar { get; set; }
        public Korisnici Korisnici { get; set; }
        public DateTime Datum{ get; set; }
    }
}
