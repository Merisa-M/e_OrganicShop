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
    public class NarudzbaStavkeService : CRUDService<Model.NarudzbaStavke, NarudzbeStavkeSearchRequest, Database.NarudzbaStavke, NarudzbaStavkaUpsertRequest, NarudzbaStavkaUpsertRequest>
    {
        private readonly eOrganicShopContext _context;
        private readonly IMapper _mapper;


        public NarudzbaStavkeService(eOrganicShopContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<List<Model.NarudzbaStavke>> Get(NarudzbeStavkeSearchRequest request)
        {
            var query = _context.NarudzbaStavke.
           Include(z => z.Proizvod)
           .AsQueryable();
            if (request?.NarudzbaId != 0)
            {
                query = query.Where(x => x.NarudzbaId == request.NarudzbaId);
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.NarudzbaStavke>>(list);



            //if (request?.NarudzbeStavkeID != 0)
            //{
            //    query = query.Where(x => x.NarudzbaStavkeID == request.NarudzbeStavkeID);


            //}
            //var lista = query.ToList();

            //List<NarudzbaStavke> result = new List<NarudzbaStavke>();

            //foreach (var item in lista)
            //{

            //    NarudzbaStavke nova = new NarudzbaStavke();

            //    nova.NarudzbaId = item.NarudzbaId;
            //    nova.Cijena = item.Cijena;
            //    nova.Kolicina = item.Kolicina;
            //    nova.Popust = item.Popust;
            //    nova.ProizvodId = item.ProizvodId;
            //    result.Add(nova);

            //}

            //return _mapper.Map<List<Model.NarudzbaStavke>>(result);
        }
        public override async Task<Model.NarudzbaStavke> Insert(NarudzbaStavkaUpsertRequest request)
        {
            var entity = _mapper.Map<NarudzbaStavke>(request);

            _context.Set<NarudzbaStavke>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.NarudzbaStavke>(entity);

        }
        public override async Task<Model.NarudzbaStavke> Update(int ID, NarudzbaStavkaUpsertRequest request)
        {

            var entity = _context.Set<NarudzbaStavke>().Find(ID);
            _context.Set<NarudzbaStavke>().Attach(entity);
            _context.Set<NarudzbaStavke>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.NarudzbaStavke>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var narudzbaStavka = await _context.NarudzbaStavke.Where(c => c.NarudzbaId == ID).FirstOrDefaultAsync();

            if (narudzbaStavka != null)
            {
                var narudzbe = await _context.NarudzbaStavke.Where(i => i.NarudzbaId == ID).ToListAsync();
                if (narudzbe != null)
                    _context.NarudzbaStavke.RemoveRange(narudzbe);

                return true;
            }
            return false;
        }
    }
}
