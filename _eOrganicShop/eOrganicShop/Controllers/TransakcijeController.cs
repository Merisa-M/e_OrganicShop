using eOrganicShop.Model.Request;
using eOrganicShop.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Controllers
{

    public class TransakcijeController : BaseCRUDController<Model.Transakcije, TransakcijeSearchRequest, TransakcijeUpsertRequest, TransakcijeUpsertRequest>
    {
        public TransakcijeController(ICRUDService<Model.Transakcije, TransakcijeSearchRequest, TransakcijeUpsertRequest, TransakcijeUpsertRequest> service) : base(service)
        {

        }
    }
}
