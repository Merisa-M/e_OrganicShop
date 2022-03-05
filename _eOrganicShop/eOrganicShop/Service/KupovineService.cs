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
    public class KupovineService : CRUDService<Model.Kupovine, KupovineSearchRequest, Kupovine, KupovineUpsertRequest, KupovineUpsertRequest>
    {
        private readonly eOrganicShopContext _context;
        private readonly IMapper _mapper;
        public KupovineService(eOrganicShopContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<List<Model.Kupovine>> Get(KupovineSearchRequest request)
        {
            var query = _context.Kupovine.AsQueryable();

            if (request.Od != null)
            {
                query = query.Where(i => i.DatumKupovine >= request.Od);
            }
            if (request.Do != null)
            {
                query = query.Where(i => i.DatumKupovine <= request.Do);
            }
            if (request.ProizvodID != 0)
            {
                query = query.Where(i => i.NarudzbaID == request.NarudzbaID);
            }

            var list = await query.ToListAsync();

            return _mapper.Map<List<Model.Kupovine>>(query);
        }
    }
}
