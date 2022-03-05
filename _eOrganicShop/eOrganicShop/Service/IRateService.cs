using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public interface IRateService
    {

        Task<List<Model.Rate>> Get(RateSearchRequest search);
        Task<Model.Rate> GetById(int ID);
        Task<Model.Rate> Insert(RateUpsertRequest request);
        Task<Model.Rate> Update(int ID, RateUpsertRequest request);
        Task<bool> Delete(int ID);
    }
}
