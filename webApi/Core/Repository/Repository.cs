using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DB.Context;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PostsContext _context;

        public Repository(PostsContext context)
        {
            _context = context;
        }

        protected PostsContext GetContext()
        {
            return _context;
        }

        public T Add(T Entity)
        {
            var context = GetContext();
            context.Entry(Entity).State = EntityState.Added;
            context.SaveChanges();
            return Entity;
        }

        public IList<T> Include<TProperty>(System.Linq.Expressions.Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            List<T> list;
            var context = GetContext();
            IQueryable<T> dbQuery = context.Set<T>();
            list = dbQuery.Include(navigationPropertyPath).ToList<T>();
            return list;
        }

        public IList<T> List(System.Linq.Expressions.Expression<Func<T, bool>> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            var context = GetContext();
            IQueryable<T> dbQuery = context.Set<T>();

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<T>();
            return list;
        }

        public IList<T> ListAll()
        {
            List<T> list;
            var context = GetContext();
            IQueryable<T> dbQuery = context.Set<T>();
            list = dbQuery.ToList<T>();

            return list;
        }

        public void Remove(T Entity)
        {
            var context = GetContext();
            context.Entry(Entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(T Entity)
        {
            var context = GetContext();
            context.Entry(Entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
