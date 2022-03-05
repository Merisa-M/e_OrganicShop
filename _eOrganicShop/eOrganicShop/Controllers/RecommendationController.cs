using eOrganicShop.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _service;
        public RecommendationController(IRecommendationService service)
        {
            _service = service;
        }
        [HttpGet("GetPreporuceneProizvode")]
        public Task<List<Model.Proizvodi>> GetPreporuceneProizvode(int KorisnikID)
        {
            return _service.GetPreporuceneProizvode(KorisnikID);
        }
    }
}
