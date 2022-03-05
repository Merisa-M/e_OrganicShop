using eOrganicShop.Model.Request;
using eOrganicShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Controllers
{
    public class NarudzbaStavkeController : BaseCRUDController<Model.NarudzbaStavke, NarudzbeStavkeSearchRequest, NarudzbaStavkaUpsertRequest, NarudzbaStavkaUpsertRequest>
    {
        public NarudzbaStavkeController(ICRUDService<Model.NarudzbaStavke, NarudzbeStavkeSearchRequest, NarudzbaStavkaUpsertRequest, NarudzbaStavkaUpsertRequest> _service) : base(_service)
        {
        }
    }
}
