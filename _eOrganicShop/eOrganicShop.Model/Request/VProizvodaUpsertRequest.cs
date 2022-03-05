using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class VProizvodaUpsertRequest
    {
        [Required]
        public string Naziv { get; set; }
    }
}
