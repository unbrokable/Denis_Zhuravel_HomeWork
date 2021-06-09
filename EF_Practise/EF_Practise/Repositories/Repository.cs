using EF_Practise.Data;
using EF_Practise.Interfaces;
using EFlecture.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EF_Practise.Repositories
{
    class Repository : IRepository
    {
        private readonly ApplicationContext context;
        public Repository(ApplicationContext context)
        {
            this.context = context;
        }

        public T Find<T>(Specification<T> specification) where T : class, new()
        {
           
            return context.Set<T>().FirstOrDefault(specification.Expression);
        }

        public IEnumerable<T> Get<T>(Specification<T> specification) where T : class, new()
        {
            return context.Set<T>().Where(specification.Expression);
        }
    }
}
