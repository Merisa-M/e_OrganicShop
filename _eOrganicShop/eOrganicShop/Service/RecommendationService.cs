using AutoMapper;
using eOrganicShop.Database;
//using eOrganicShop.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public class RecommendationService : IRecommendationService
    {
        private readonly eOrganicShopContext _context;
        private readonly IMapper _mapper;
        public RecommendationService(eOrganicShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Model.Proizvodi>> GetPreporuceneProizvode(int KorisnikID)
        {
            try
            {
                if (KorisnikID == 0)
                {
                    throw new Exception();
                }
                List<Rate> korisnickeOcjene = await _context.Rate.Where(x => x.KorisnikID == KorisnikID)
                    .Include(x => x.Korisnik)
                    .Include(x => x.Proizvod)
                    .Include(x => x.Proizvod.VrstaProizvoda)
                    .Include(x => x.Proizvod.Korisnik)
                    .ToListAsync();

                List<Database.Rate> najboljeOcijenjeniProizvodi = korisnickeOcjene
                    .Where(x => x.Rating >= 3)
                    .ToList();
                if (najboljeOcijenjeniProizvodi.Count > 0)
                {
                    List<Database.VrsteProizvoda> vrsteProizvoda = new List<Database.VrsteProizvoda>();

                    foreach (var vrstaProizvoda in najboljeOcijenjeniProizvodi)
                    {
                        var proizvodovaVrstaProizvoda = await _context.Proizvodi.Where(m => m.VrstaProizvodaID == vrstaProizvoda.Proizvod.VrstaProizvodaID)
                           .Select(s => s.VrstaProizvoda)
                           .ToListAsync();

                        foreach (var x in proizvodovaVrstaProizvoda)
                        {
                            bool add = true;
                            for (int i = 0; i < vrsteProizvoda.Count; i++)
                            {
                                if (x.Naziv == vrsteProizvoda[i].Naziv)
                                {
                                    add = false;
                                }
                            }
                            if (add)
                            {
                                vrsteProizvoda.Add(x);
                            }
                        }
                    }


                    List<Database.Proizvodi> finalni = new List<Database.Proizvodi>();
                    var korisnickiKupljeniProizvodi = await _context.Kupovine.Where(k => k.KorisnikID == KorisnikID).Include(k => k.Narudzba).ThenInclude(n => n.NarudzbaStavke).ToListAsync();
                    foreach (var item in vrsteProizvoda)
                    {
                        var vrstaProizvodaListeProizvoda = await _context.Proizvodi
                            .Where(s => s.VrstaProizvodaID == item.VrsteProizvodaID)
                            .Include(i => i.Korisnik)
                            .ToListAsync();

                        foreach (var proizvod in vrstaProizvodaListeProizvoda)
                        {
                            bool add = true;
                            var DaLiSadrzi = korisnickiKupljeniProizvodi.Where(m => m.Narudzba.NarudzbaStavke.Any(ns => ns.ProizvodId == proizvod.ProizvodID)).Any();
                            if (DaLiSadrzi == false)
                            {
                                for (int i = 0; i < finalni.Count; i++)
                                {
                                    if (proizvod.NazivProizvoda == finalni[i].NazivProizvoda)
                                    {
                                        add = false;
                                    }
                                }
                                foreach (var rate in korisnickeOcjene)
                                {
                                    if (proizvod.NazivProizvoda == rate.Proizvod.NazivProizvoda)
                                    {
                                        add = false;
                                    }
                                }
                                if (add)
                                {
                                    finalni.Add(proizvod);
                                }
                            }


                        }
                    }


                    finalni = finalni.OrderBy(x => Guid.NewGuid()).Take(3).ToList();

                    return _mapper.Map<List<Model.Proizvodi>>(finalni);
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                return _mapper.Map<List<Model.Proizvodi>>(null);
            }
        }
    }
}
