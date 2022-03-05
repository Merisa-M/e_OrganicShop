using AutoMapper;
using eOrganicShop.Database;
using eOrganicShop.Model.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public class NarudzbaService : CRUDService<Model.Narudzba, NarudzbaSearchRequest, Database.Narudzba, NarudzbaUpsertRequest, NarudzbaUpsertRequest>, INarudzbaService
    {
        private readonly eOrganicShopContext _context;
        private readonly IMapper _mapper;


        public NarudzbaService(eOrganicShopContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<Model.Narudzba>> Get(NarudzbaSearchRequest request)
        {
            var query = _context.Narudzba.
               Include(z => z.Korisnik)
               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.BrojNarudzbe))
            {
                query = query.Where(x => x.BrojNarudzbe.StartsWith(request.BrojNarudzbe));


            }

            var lista = query.ToList();

            List<Narudzba> result = new List<Narudzba>();

            foreach (var item in lista)
            {

                Narudzba nova = new Narudzba();

                nova.BrojNarudzbe = item.BrojNarudzbe;
                nova.Datum = item.Datum;
                nova.Iznos = item.Iznos;
                nova.KorisnikID = item.Korisnik.KorisnikID;
                nova.NarudzbaID = item.NarudzbaID;

                result.Add(nova);


            }

            return _mapper.Map<List<Model.Narudzba>>(result);
        }
        public override async Task<Model.Narudzba> Insert(NarudzbaUpsertRequest request)
        {
            var entity = _mapper.Map<Narudzba>(request);

            _context.Set<Narudzba>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Narudzba>(entity);

        }
        public override async Task<Model.Narudzba> Update(int ID, NarudzbaUpsertRequest request)
        {

            var entity = _context.Set<Narudzba>().Find(ID);
            _context.Set<Narudzba>().Attach(entity);
            _context.Set<Narudzba>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Narudzba>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var narudzba = await _context.Narudzba.Where(c => c.NarudzbaID == ID).FirstOrDefaultAsync();

            if (narudzba != null)
            {

                await _context.SaveChangesAsync();


                _context.Narudzba.Remove(narudzba);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public Model.Narudzba GetByBrojNarudzbe(string brNarudzbe)
        {
            var entity = _context.Narudzba.Where(n => n.BrojNarudzbe.Contains(brNarudzbe)).FirstOrDefault();

            if (entity == null)
            {
                throw new UserException("Narudzba ne postoji!");
            }

            return _mapper.Map<Model.Narudzba>(entity);
        }
    }
}
