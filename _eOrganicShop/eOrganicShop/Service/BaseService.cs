using AutoMapper;
using eOrganicShop.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eOrganicShop.Service
{
    public class BaseService<TModel, TSearch, TDatabase> : IBaseService<TModel, TSearch> where TDatabase : class
    {
        protected eOrganicShopContext _context;
        protected IMapper _mapper;
        public BaseService(eOrganicShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual async Task<List<TModel>> Get(TSearch search)
        {
            var list = await _context.Set<TDatabase>().ToListAsync();
            return _mapper.Map<List<TModel>>(list);
        }
        public virtual async Task<TModel> GetById(int ID)
        {
            var entity = await _context.Set<TDatabase>().FindAsync(ID);
            return _mapper.Map<TModel>(entity);
        }
    }
    }
