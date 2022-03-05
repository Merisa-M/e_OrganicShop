using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using eOrganicShop.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : BaseCRUDController<Model.Korisnici, KorisnikSearchRequest, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {

        private readonly IKorisniciService _service;
        public KorisniciController(IKorisniciService service) : base(service)
        {
            _service = service;
        }
        [HttpPost("Authenticate")]
        public async Task<Model.Korisnici> Authenticate(UserAuthenticationRequest request)
        {
            return await _service.Authenticate(request);
        }
        [HttpPost("Login")]
        public async Task<Model.Korisnici> Register(KorisnikUpsertRequest request)
        {
            return await _service.Insert(request);
        }
        [HttpGet("{ID}/LikedProizvodi")]
        [Authorize]
        public async Task<List<Proizvodi>> GetLikedProizvodi(int ID, [FromQuery] ProizvodiSearchRequest request)
        {
            return await _service.GetLikedProizvodi(ID, request);
        }
        [HttpPost("{ID}/LikedProizvodi/{ProizvodID}")]
        [Authorize]
        public async Task<Proizvodi> InsertLikedProizvodi(int ID, int ProizvodID)
        {
            return await _service.InsertLikedProizvodi(ID, ProizvodID);
        }
        [HttpDelete("{ID}/LikedProizvodi/{ProizvodID}")]
        [Authorize]
        public async Task<Proizvodi> DeleteLikedProizvodi(int ID, int ProizvodID)
        {
            return await _service.DeleteLikedProizvodi(ID, ProizvodID);
        }
    }
}
