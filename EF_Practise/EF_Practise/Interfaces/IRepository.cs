using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Practise.Interfaces
{
    interface IRepository
    {
        T Find<T>(Specification<T> specification) where T : class, new();
        IQueryable<T> Get<T>(Specification<T> specification) where T : class, new();
    }
}
