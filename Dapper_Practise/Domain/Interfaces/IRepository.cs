using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository
    {
        IEnumerable<T> GetBy<T>(Expression<Func<T, object>> expression, object value) where T: class;
        T Find<T>(Expression<Func<T, object>> expression, object value) where T : class;
        void Update<T>(T data) where T : class;
        public void Update<T>(IEnumerable<T> datas) where T : class;
        void Add<T>(T data) where T : class;
        void Remove<T>(T data) where T : class;
        void Remove<T>(IEnumerable<T> data) where T : class;
    }
}
