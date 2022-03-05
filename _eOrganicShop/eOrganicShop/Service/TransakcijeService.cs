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
    public class TransakcijeService : CRUDService<Model.Transakcije, TransakcijeSearchRequest, Transakcije, TransakcijeUpsertRequest, TransakcijeUpsertRequest>
    {
        private readonly eOrganicShopContext _context;
        private readonly IMapper _mapper;
        public TransakcijeService(eOrganicShopContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<Model.Transakcije>> Get(TransakcijeSearchRequest request)
        {
            var query = _context.Transakcije.Include(n=> n.Narudzba).AsQueryable().OrderBy(c => c.DatumTranskacije);

            if (request.KorisnikID != 0)
            {
                query = (IOrderedQueryable<Transakcije>)query.Where(i => i.KorisnikID == request.KorisnikID);
            }

        
            if (request.From != null)
            {
                query = (IOrderedQueryable<Transakcije>)query.Where(i => i.DatumTranskacije >= request.From);
            }
            if (request.To != null)
            {
                query = (IOrderedQueryable<Transakcije>)query.Where(i => i.DatumTranskacije <= request.To);
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<Model.Transakcije>>(list);
        }
        public override async Task<Model.Transakcije> GetById(int ID)
        {
            var entity = await _context.Transakcije
                .Where(i => i.TransakcijaID == ID)
                .SingleOrDefaultAsync();

            return _mapper.Map<Model.Transakcije>(entity);
        }
        public override async Task<Model.Transakcije> Insert(TransakcijeUpsertRequest request)
        {

            var entity = _mapper.Map<Transakcije>(request);

            _context.Set<Transakcije>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Transakcije>(entity);
        }
        public override async Task<Model.Transakcije> Update(int ID, TransakcijeUpsertRequest request)
        {


            var entity = _context.Set<Transakcije>().Find(ID);
            _context.Set<Transakcije>().Attach(entity);
            _context.Set<Transakcije>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Transakcije>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var transakcija = await _context.Transakcije.Where(i => i.TransakcijaID == ID).FirstOrDefaultAsync();
            if (transakcija != null)
            {
                _context.Transakcije.Remove(transakcija);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

    }
}