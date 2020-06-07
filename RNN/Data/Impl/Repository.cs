using Microsoft.EntityFrameworkCore;
using RNN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RNN.Data.Impl
{
    public class EditTracker<T>
    {
        private HashSet<string> _fields;

        public EditTracker()
        {
            _fields = new HashSet<string>();
        }

        public void Track<P>(Expression<Func<T, P>> propertyExpression)
        {
            _fields.Add((propertyExpression.Body as MemberExpression).Member.Name);
        }

        public ISet<string> Fields => _fields;
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _set;

        public Repository(IUnitOfWork unit)
        {
            _set = unit.GetContext().Set<T>();
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
            return _set.Where(predicate);
        }

        public IQueryable<T> QueryAll()
        {
            return _set;
        }

        public void Update<P>(T entity, Expression<Func<T, P>> propertyExpression)
        {
            var tracker = _set.Attach(entity);

            var member = (propertyExpression.Body as MemberExpression).Member.Name;

            var modify = tracker
                .Properties
                .FirstOrDefault(p => p.Metadata.Name == member);

            modify.IsModified = true;
        }

        public void Update(T entity, EditTracker<T> tracker)
        {
            var set = tracker.Fields;

            var props = _set.Attach(entity)
                .Properties
                .Where(p => set.Contains(p.Metadata.Name));

            foreach (var p in props)
                p.IsModified = true;
        }
    }
}
