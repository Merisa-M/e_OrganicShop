using AutoMapper;
using eOrganicShop.Database;
using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Mapping
{
    public class eOrganicShopProfile : Profile
    {
        public eOrganicShopProfile()
        {
            CreateMap<VrsteProizvoda, Model.VrsteProizvoda>();
            CreateMap<VrsteProizvoda, VProizvodaSearchRequest>().ReverseMap();
            CreateMap<VrsteProizvoda, VProizvodaUpsertRequest>().ReverseMap();

            CreateMap<Korisnici, Model.Korisnici>();
            CreateMap<Korisnici, KorisnikUpsertRequest>().ReverseMap();

            CreateMap<Proizvodi, Model.Proizvodi>().ReverseMap();
            CreateMap<Proizvodi, ProizvodiUpsertRequest>().ReverseMap();

            CreateMap<Narudzba, Model.Narudzba>();
            CreateMap<Narudzba, NarudzbaUpsertRequest>().ReverseMap();

            CreateMap<NarudzbaStavke, Model.NarudzbaStavke>().ReverseMap();
            CreateMap<NarudzbaStavke, NarudzbaStavkaUpsertRequest>().ReverseMap();

            CreateMap<Uloge, Model.Uloge>();
            CreateMap<KorisnikUloge, Model.KorisnikUloge>();

            CreateMap<Uloge, Model.Uloge>();
            CreateMap<KorisnikUloge, Model.KorisnikUloge>();

            CreateMap<Transakcije, Model.Transakcije>();
            CreateMap<Transakcije, TransakcijeUpsertRequest>().ReverseMap();

            CreateMap<Review, Model.Review>();
            CreateMap<Review, ReviewUpsertRequest>().ReverseMap();

            CreateMap<Rate, Model.Rate>();
            CreateMap<Rate, RateUpsertRequest>().ReverseMap();

            CreateMap<Kupovine, Model.Kupovine>();
            CreateMap<Kupovine, KupovineUpsertRequest>().ReverseMap();

            CreateMap<Favoriti, Model.Favoriti>();
            CreateMap<Favoriti, FavoritiUpsertRequest>().ReverseMap();

        }
    }
}
