using eOrganicShop.Model.Request;
using eOrganicShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Controllers
{
    public class KupovineController : BaseCRUDController<Model.Kupovine, KupovineSearchRequest, KupovineUpsertRequest, KupovineUpsertRequest>
    {
        public KupovineController(ICRUDService<Model.Kupovine, KupovineSearchRequest, KupovineUpsertRequest, KupovineUpsertRequest> _service) : base(_service)
        {
        }
    }
}
