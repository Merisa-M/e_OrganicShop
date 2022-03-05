using AutoMapper;
using eOrganicShop.Database;
using eOrganicShop.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public class RateService : IRateService
    {
        private readonly eOrganicShopContext _context;
        private readonly IMapper _mapper;
        public RateService(eOrganicShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Model.Rate>> Get(RateSearchRequest search)
        {

            var query = _context.Rate.AsQueryable();

            if (search.KorisnikID != 0)
            {
                query = query.Where(i => i.KorisnikID == search.KorisnikID);
            }

            if (search.ProizvodID != 0)
            {
                query = query.Where(i => i.ProizvodID == search.ProizvodID);
            }

            if (search.Rating != 0)
            {
                query = query.Where(i => i.Rating == search.Rating);
            }

            var list = await query.ToListAsync();
            return _mapper.Map<List<Model.Rate>>(list);
        }

        public async Task<Model.Rate> GetById(int ID)
        {
            var entity = await _context.Rate
               .Include(i => i.Proizvod)
               .Where(i => i.KorisnikID == ID)
               .SingleOrDefaultAsync();

            return _mapper.Map<Model.Rate>(entity);
        }

        public async Task<Model.Rate> Insert(RateUpsertRequest request)
        {
            var entity = _mapper.Map<Rate>(request);
            _context.Set<Rate>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Rate>(entity);
        }

        public async Task<Model.Rate> Update(int ID, RateUpsertRequest request)
        {
            var entity = _context.Set<Rate>().Find(ID);
            _context.Set<Rate>().Attach(entity);
            _context.Set<Rate>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Rate>(entity);
        }

        public async Task<bool> Delete(int ID)
        {
            var rate = await _context.Rate.Where(i => i.KorisnikID == ID).Include(i => i.ProizvodID).FirstOrDefaultAsync();
            if (rate != null)
            {
                _context.Rate.Remove(rate);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
