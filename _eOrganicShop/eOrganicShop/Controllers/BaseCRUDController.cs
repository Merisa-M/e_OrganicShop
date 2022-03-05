﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eOrganicShop.Database;
using eOrganicShop.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eOrganicShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseReadController<T, TSearch>
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }
        [HttpPost]
        [Authorize(Roles = "Admin, Kupac")]
        public async Task<T> Insert(TInsert request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{ID}")]
        [Authorize]
        public async Task<T> Update(int ID, TUpdate request)
        {
            return await _service.Update(ID, request);
        }
        [HttpDelete("{ID}")]
        [Authorize(Roles = "Admin")]

        public async Task<bool> Delete(int ID)
        {
            return await _service.Delete(ID);
        }
    }
}