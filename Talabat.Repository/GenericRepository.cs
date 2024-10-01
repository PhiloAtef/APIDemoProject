﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repository.Contract;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbcontext;
        public GenericRepository(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Product))
            {
                return (IEnumerable<T>)await _dbcontext.Set<Product>().Include(b => b.Brand).Include(c => c.Category).ToListAsync();
            }
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            if (typeof(T) == typeof(Product))
            {
                return await _dbcontext.Set<Product>().Where(p=> p.Id == id).Include(b => b.Brand).Include(c => c.Category).FirstOrDefaultAsync() as T;
            }
            return await _dbcontext.Set<T>().FindAsync(id);
        }
    }
}
