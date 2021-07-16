using EF_Practise.Data;
using EF_Practise.Interfaces;
using EFlecture.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Practise.Repositories
{
    class Repository : IRepository
    {
        private readonly ApplicationContext context;
        public Repository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<T> FindAsync<T>(Specification<T> specification) where T : class, new()
        {
           
            return await context.Set<T>().FirstOrDefaultAsync(specification.Expression);
        }

        public Task<IQueryable<T>> GetAsync<T>(Specification<T> specification) where T : class, new()
        {
            return Task.FromResult(context.Set<T>().Where(specification.Expression));
        }

    }
}
