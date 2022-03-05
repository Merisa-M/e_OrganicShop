using AutoMapper;
using eOrganicShop.Database;
using eOrganicShop.Exceptions;
using eOrganicShop.Model.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public class ProizvodiService : CRUDService<Model.Proizvodi, ProizvodiSearchRequest, Database.Proizvodi, ProizvodiUpsertRequest, ProizvodiUpsertRequest>, IProizvodiService
    {
        private readonly eOrganicShopContext _context;
        private readonly IMapper _mapper;
        public ProizvodiService(eOrganicShopContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<List<Model.Proizvodi>> Get(ProizvodiSearchRequest request)
        {
            var query = _context.Proizvodi.Include(i => i.Korisnik).AsQueryable().OrderBy(c => c.NazivProizvoda);

            if (request.KorisnikID != 0)
            {
                query = query.Where(x => x.KorisnikID == request.KorisnikID).Include(i => i.Korisnik).OrderBy(c => c.NazivProizvoda);
            }

            if (request?.VrsteProizvodaID.HasValue == true)
            {
                query = query.Where(x => x.VrstaProizvodaID == request.VrsteProizvodaID).Include(i => i.VrstaProizvoda).Include(i => i.Korisnik).OrderBy(c => c.NazivProizvoda);
            }

            if (!string.IsNullOrWhiteSpace(request?.NazivProizvoda))
            {
                query = query.Where(x => x.NazivProizvoda.Contains(request.NazivProizvoda)).Include(i => i.Korisnik).OrderBy(c => c.NazivProizvoda);
            }
            var list = await query.ToListAsync();

            return _mapper.Map<List<Model.Proizvodi>>(list);
        }


        public override async Task<Model.Proizvodi> Insert(ProizvodiUpsertRequest request)
        {
            var entity = _mapper.Map<Proizvodi>(request);

            _context.Set<Proizvodi>().Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Proizvodi>(entity);
        }
        public override async Task<Model.Proizvodi> Update(int ID, ProizvodiUpsertRequest request)
        {
            var proizvod = await _context.Proizvodi.FindAsync(ID);
            if (await _context.Proizvodi.AnyAsync(i => i.NazivProizvoda == request.NazivProizvoda) && request.NazivProizvoda != proizvod.NazivProizvoda)
            {
                throw new UserException("Proizvod vec postoji!");
            }

            var entity = _context.Set<Proizvodi>().Find(ID);
            _context.Set<Proizvodi>().Attach(entity);
            _context.Set<Proizvodi>().Update(entity);

            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Proizvodi>(entity);
        }
        public override async Task<bool> Delete(int ID)
        {
            var proizvod = await _context.Proizvodi.Where(c => c.ProizvodID == ID).FirstOrDefaultAsync();

            if (proizvod != null)
            {

                await _context.SaveChangesAsync();


                _context.Proizvodi.Remove(proizvod);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }
        public async Task<float> GetProsjek(int ProizvodID)
        {
            var list = await _context.Rate.Where(i => i.ProizvodID == ProizvodID).ToListAsync();
            if (list.Count() != 0)
            {
                return (float)list.Average(i => i.Rating);
            }
            return 0;
        }

    }
}
