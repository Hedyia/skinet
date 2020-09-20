using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications
{
    public class BaseSepcification<T> : ISpecification<T>
    {
        public BaseSepcification()
        {

        }
        public BaseSepcification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; }
        = new List<Expression<Func<T, object>>>();

        protected void Include(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}