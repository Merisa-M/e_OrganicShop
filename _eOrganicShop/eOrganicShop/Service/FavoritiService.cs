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
    public class FavoritiService : CRUDService<Model.Favoriti, FavoritiSearchRequest, Favoriti, FavoritiUpsertRequest, FavoritiUpsertRequest>
    {
        private readonly eOrganicShopContext _context;
        private readonly IMapper _mapper;

        public FavoritiService(eOrganicShopContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<Model.Favoriti>> Get(FavoritiSearchRequest request)
        {
            var query = _context.Favoriti.AsQueryable();

            if (request.KorisnikID != 0)
            {
                query = (IOrderedQueryable<Favoriti>)query.Where(x => x.KorisnikID == request.KorisnikID);
            }

            if (request.KorisnikID != 0 && request.ProizvodID != 0)
            {
                query = (IOrderedQueryable<Favoriti>)query.Where(x => x.KorisnikID == request.KorisnikID && x.ProizvodID == request.ProizvodID);
            }

            var list = await query.ToListAsync();
            return _mapper.Map<List<Model.Favoriti>>(list);
        }
        public override async Task<Model.Favoriti> Update(int ID, FavoritiUpsertRequest request)
        {
            var entity = _context.Set<Favoriti>().Find(ID);
            _context.Set<Favoriti>().Attach(entity);
            _context.Set<Favoriti>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Favoriti>(entity);
        }

    }
}
