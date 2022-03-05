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
    public class ReviewController : Controller
    {
        private readonly IReviewService _service;
        public ReviewController(IReviewService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<Review>> Get([FromQuery] ReviewSearchRequest search)
        {
            return await _service.Get(search);
        }
        [HttpGet("{ID}")]
        public async Task<Review> GetById(int ID)
        {
            return await _service.GetById(ID);
        }
        [HttpPost]
        public async Task<Review> Insert(ReviewUpsertRequest request)
        {
            return await _service.Insert(request);
        }
        [HttpPut("{ID}")]
        public async Task<Review> Update(int ID, ReviewUpsertRequest request)
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
