using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class ProizvodiUpsertRequest
    {
        [Required]
        public string NazivProizvoda { get; set; }
        [Required]
        public string Sifra { get; set; }
        [Required]
        public float Cijena { get; set; }
        public string Opis { get; set; }
        public int VrstaProizvodaID { get; set; }
        public byte[] Slika { get; set; }
        public int KorisnikID { get; set; }

    }
}
