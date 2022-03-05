using eOrganicShop.Model.Request;
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
    public class FavoritiController : BaseCRUDController<Model.Favoriti, FavoritiSearchRequest, FavoritiUpsertRequest, FavoritiUpsertRequest>
    {
        public FavoritiController(ICRUDService<Model.Favoriti, FavoritiSearchRequest, FavoritiUpsertRequest, FavoritiUpsertRequest> service) : base(service)
        {

        }
    }
}
