using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class VrsteProizvoda
    {
        [Key]
        public int VrsteProizvodaID { get; set; }
        public string Naziv { get; set; }
    }
}
