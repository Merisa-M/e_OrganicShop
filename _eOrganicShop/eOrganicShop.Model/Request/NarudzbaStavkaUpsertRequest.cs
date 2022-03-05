using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class NarudzbaStavkaUpsertRequest
    {
        public int? ProizvodID { get; set; }
        public int NarudzbaID { get; set; }
    
        public int Kolicina { get; set; }
        public float Cijena { get; set; }
        public decimal? Popust { get; set; }
   
    }
}
