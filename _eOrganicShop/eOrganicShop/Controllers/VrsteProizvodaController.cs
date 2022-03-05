using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eOrganicShop.Model;
using eOrganicShop.Model.Request;
using eOrganicShop.Service;
using Microsoft.AspNetCore.Mvc;

namespace eOrganicShop.Controllers
{
    public class VrsteProizvodaController : BaseCRUDController<VrsteProizvoda, VProizvodaSearchRequest, VProizvodaUpsertRequest, VProizvodaUpsertRequest>
    {
        public VrsteProizvodaController(ICRUDService<Model.VrsteProizvoda, VProizvodaSearchRequest, VProizvodaUpsertRequest, VProizvodaUpsertRequest> service) : base(service)
        {

        }
    }
}