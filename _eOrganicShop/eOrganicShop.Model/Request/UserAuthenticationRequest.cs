using System;
using System.Collections.Generic;
using System.Text;

namespace eOrganicShop.Model.Request
{
    public class UserAuthenticationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
