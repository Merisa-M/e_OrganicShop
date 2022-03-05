
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
   public interface IReviewService
    {
        Task<List<Review>> Get(ReviewSearchRequest search);
        Task<Review> GetById(int ID);
        Task<Review> Insert(ReviewUpsertRequest request);
        Task<Review> Update(int ID, ReviewUpsertRequest request);
        Task<bool> Delete(int ID);
    }
}
