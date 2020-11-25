using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Repository
{
    public interface IRepository<T> where T : class 
    {
        IList<T> ListAll();
        IList<T> List(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        IList<T> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath);
        T Add(T item);
        void Update(T item);
        void Remove(T item);
    }
}
