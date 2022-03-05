using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Database
{
    public class NarudzbaStavke
    {
        [Key]
        public int NarudzbaStavkeID { get; set; }
        public int NarudzbaId { get; set; }
        public int ProizvodId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Popust { get; set; }
        public float? Cijena { get; set; }

        public int? Kolicina { get; set; }
        public virtual Proizvodi Proizvod { get; set; }
        public virtual Narudzba Narudzba { get; set; }
    }
}
