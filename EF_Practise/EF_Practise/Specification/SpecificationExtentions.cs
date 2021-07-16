
using System;
using System.Linq.Expressions;


namespace EFlecture.Core.Specifications
{
    public static class SpecificationExtentions
    {
        public static Specification<T> Or<T>(this Specification<T> left, Specification<T> right)
            where T : class, new()
        {
            var leftExpr = left.Expression;
            var rightExpr = right.Expression;
            var leftParam = leftExpr.Parameters[0];
            var rightParam = rightExpr.Parameters[0];

            return new Specification<T>(
                Expression.Lambda<Func<T, bool>>(
                    Expression.OrElse(
                        leftExpr.Body,
                        new ParameterReplacer(rightParam, leftParam).Visit(rightExpr.Body)),
                    leftParam));
        }

        public static Specification<T> And<T>(this Specification<T> left, Specification<T> right)
            where T : class, new()
        {
            var leftExpr = left.Expression;
            var rightExpr = right.Expression;
            var leftParam = leftExpr.Parameters[0];
            var rightParam = rightExpr.Parameters[0];

            return new Specification<T>(
                Expression.Lambda<Func<T, bool>>(
                    Expression.AndAlso(
                        leftExpr.Body,
                        new ParameterReplacer(rightParam, leftParam).Visit(rightExpr.Body)),
                    leftParam));
        }

        public static Specification<T> Not<T>(this Specification<T> specification)
            where T: class, new()
        {
            return new Specification<T>(
                Expression.Lambda<Func<T, bool>>(
                    Expression.Not(specification.Expression.Body),
                    specification.Expression.Parameters));
        }
    }
}
