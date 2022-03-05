using eOrganicShop.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public interface IKorisniciService : ICRUDService<Model.Korisnici, KorisnikSearchRequest, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {
        Task<Model.Korisnici> Authenticate(UserAuthenticationRequest request);
        Task<Model.Korisnici> Login(KorisnikUpsertRequest request);
        Task<List<Model.Proizvodi>> GetLikedProizvodi(int ID, ProizvodiSearchRequest request);
        Task<Model.Proizvodi> InsertLikedProizvodi(int ID, int ProizvodID);
        Task<Model.Proizvodi> DeleteLikedProizvodi(int ID, int ProizvodID);
    }
}
