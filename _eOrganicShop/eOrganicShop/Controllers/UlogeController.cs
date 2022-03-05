using eOrganicShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Controllers
{
    public class UlogeController : BaseReadController<Model.Uloge, object>
    {
        public UlogeController(IBaseService<Model.Uloge, object> service) : base(service)
        {
        }
    }
}
