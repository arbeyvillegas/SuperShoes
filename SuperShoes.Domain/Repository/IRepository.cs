using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace SuperShoes.Domain.Repository
{
    public interface IRepository<T>
    {
        
        T Add(T entity);

        T Delete(T entity);

        T PrepareUpdate(T entity);

        void Update(T entity);

        IQueryable<T> GetAll();

        IOrderedEnumerable<T> GetAll(Func<T, object> order);

        T Get(object key);

        IEnumerable<T> GetSome(Func<T, bool> function);

        IOrderedEnumerable<T> GetSome(Func<T, bool> function, Func<T, object> order);

        void SaveChanges();

        ObjectContext GetContext();
    }
}
