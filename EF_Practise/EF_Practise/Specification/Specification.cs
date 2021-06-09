
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EFlecture.Core.Specifications
{
    public class Specification<T>
        where T: class, new()
    {
        public Expression<Func<T, bool>> Expression { get; }

        public Func<T, bool> Func => this.Expression.Compile();

        public Specification(Expression<Func<T, bool>> expression)
        {
            this.Expression = expression;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return this.Func(entity);
        }
    }
}
