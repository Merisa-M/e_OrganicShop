using AutoMapper;
using eOrganicShop.Database;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public class ReviewService : IReviewService
    {
        private readonly eOrganicShopContext _context;
        private readonly IMapper _mapper;
        public ReviewService(eOrganicShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Model.Review>> Get(ReviewSearchRequest search)
        {
            var query = _context.Review.AsQueryable();

            var list = await query.ToListAsync();
            return _mapper.Map<List<Model.Review>>(list);
        }
        public async Task<Model.Review> GetById(int ID)
        {
            var entity = await _context.Review
                .Include(i => i.Korisnik)
                .Where(i => i.ReviewID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<Model.Review>(entity);
        }
        public async Task<Model.Review> Insert(ReviewUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Review>(request);
            _context.Set<Database.Review>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Review>(entity);
        }
        public async Task<Model.Review> Update(int ID, ReviewUpsertRequest request)
        {
            var entity = _context.Set<Database.Review>().Find(ID);
            _context.Set<Database.Review>().Attach(entity);
            _context.Set<Database.Review>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Review>(entity);
        }
        public async Task<bool> Delete(int ID)
        {
            var comment = await _context.Review.Where(i => i.ReviewID == ID).FirstOrDefaultAsync();
            if (comment != null)
            {
                _context.Review.Remove(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
