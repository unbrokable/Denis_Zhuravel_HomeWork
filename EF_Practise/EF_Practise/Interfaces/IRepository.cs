using EFlecture.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Practise.Interfaces
{
    interface IRepository  
    {
        //T Find<T>(int id) where T: class, new();
        T Find<T>(Specification<T> specification) where T : class, new();
        IEnumerable<T> Get<T>(Specification<T> specification) where T : class, new();
       // void Add<T>(T entity) where T : class, new();
    }
}
