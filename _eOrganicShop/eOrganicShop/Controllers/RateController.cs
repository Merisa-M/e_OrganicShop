using eOrganicShop.Model.Request;
using eOrganicShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : Controller
    {

        private readonly IRateService _service;
        public RateController(IRateService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<Model.Rate>> Get([FromQuery] RateSearchRequest search)
        {
            return await _service.Get(search);
        }
        [HttpGet("{ID}")]
        public async Task<Model.Rate> GetById(int ID)
        {
            return await _service.GetById(ID);
        }
        [HttpPost]
        public async Task<Model.Rate> Insert(RateUpsertRequest request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{ID}")]
        public async Task<Model.Rate> Update(int ID, RateUpsertRequest request)
        {
            return await _service.Update(ID, request);
        }
        [HttpDelete("{ID}")]
        public async Task<bool> Delete(int ID)
        {
            return await _service.Delete(ID);
        }
    }
}
