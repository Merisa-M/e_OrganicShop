using AutoMapper;
using eOrganicShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public class UlogeService : BaseService<Model.Uloge, object, Uloge>
    {
        public UlogeService(eOrganicShopContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
