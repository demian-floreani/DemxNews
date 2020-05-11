using Microsoft.EntityFrameworkCore;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RNN.Data.Impl
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _set;

        public Repository(RNNContext context)
        {
            _set = context.Set<T>();
        }

        public async Task Create(T entity)
        {
            await _set.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var queryable = _set.Where(predicate);
            return queryable;
        }

        public IQueryable<T> QueryAll()
        {
            var queryable = _set;
            return queryable;
        }

        public void Update(T entity, string property)
        {
            var tracker = _set.Attach(entity);
           
            var modify = tracker
                .Properties
                .FirstOrDefault(p => p.Metadata.Name == property);

            modify.IsModified = true;
        }

        public void Update(T entity, HashSet<string> properties)
        {
            var tracker = _set.Attach(entity);

            var modify = tracker
                .Properties
                .Where(p => properties.Contains(p.Metadata.Name));

            foreach (var p in modify) 
            {
                p.IsModified = true;
            }
        }

        public void Update(T entity)
        {
            _set.Update(entity);
        }
    }
}
