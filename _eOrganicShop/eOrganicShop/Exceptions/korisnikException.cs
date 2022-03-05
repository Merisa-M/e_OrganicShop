using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Exceptions
{
    public class korisnikException : Exception
    {
        public korisnikException(string message) :
           base(message)
        {

        }
    }
    }
