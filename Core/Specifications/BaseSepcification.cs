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

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; } = false;

        protected void Include(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }
        protected void ApplyPaging(int skip, int take)
        {
            IsPagingEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}