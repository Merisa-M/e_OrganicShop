using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class KorisnikUpsertRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Telefon { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }

        public byte[] Image { get; set; }
        public List<int> Uloge { get; set; } = new List<int>();
  
    }
}
