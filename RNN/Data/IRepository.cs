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

        void Update(T entity, string property);

        void Update(T entity, HashSet<string> properties);

        void Update(T entity);

        void Delete(T entity);
    }
}
