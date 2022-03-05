using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eOrganicShop.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOrganicShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class BaseReadController<T, Tsearch> : ControllerBase
    {
        private readonly IBaseService<T, Tsearch> _service;
        public BaseReadController(IBaseService<T, Tsearch> service)
        {
            _service = service;
        }
        //[Authorize]
        [HttpGet]
        public async Task<List<T>> Get([FromQuery] Tsearch search)
        {
            return await _service.Get(search);
        }
        //[Authorize]
        [HttpGet("{ID}")]
        public async Task<T> GetById(int ID)
        {
            return await _service.GetById(ID);
        }
    }
}