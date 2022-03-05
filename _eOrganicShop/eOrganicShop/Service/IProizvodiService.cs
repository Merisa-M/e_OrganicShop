using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public interface IProizvodiService 
    {
        Task<float> GetProsjek(int ID);
        Task<List<Model.Proizvodi>> Get(ProizvodiSearchRequest search);
        Task<Model.Proizvodi> GetById(int ID);
        Task<Model.Proizvodi> Insert(ProizvodiUpsertRequest request);
        Task<Model.Proizvodi> Update(int ID, ProizvodiUpsertRequest request);
        Task<bool> Delete(int ID);
    }
}
