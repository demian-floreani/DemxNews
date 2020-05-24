using RNN.Data.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RNN.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> QueryAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        Task Create(T entity);

        void Update<P>(T entity, Expression<Func<T, P>> propertyExpression);

        void Update(T entity, EditTracker<T> tracker);

        void Delete(T entity);
    }
}
