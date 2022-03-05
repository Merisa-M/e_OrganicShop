using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class KupovineSearchRequest
    {
        public DateTime? Od { get; set; }
        public DateTime? Do { get; set; }
        public int? VrsteProizvodaID { get; set; }
        public int ProizvodID { get; set; }
        public int NarudzbaID { get; set; }

    }
}
