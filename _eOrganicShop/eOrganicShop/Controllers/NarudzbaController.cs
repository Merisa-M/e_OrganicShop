using eOrganicShop.Model.Request;
using eOrganicShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Controllers
{

    public class NarudzbaController : BaseCRUDController<Model.Narudzba, NarudzbaSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest>
    {
        private readonly INarudzbaService _service;

        public NarudzbaController(INarudzbaService service) : base(service)
        {
            _service = service;

        }

        [HttpGet("GetByBrojNarudzbe")]
        public Model.Narudzba GetByBrojNarudzbe([FromQuery] string naziv)
        {
            return _service.GetByBrojNarudzbe(naziv);
        }
    }
}
