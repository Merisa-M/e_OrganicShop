using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public interface IRecommendationService
    {
        Task<List<Model.Proizvodi>> GetPreporuceneProizvode(int KorisnikID);
    }
}
