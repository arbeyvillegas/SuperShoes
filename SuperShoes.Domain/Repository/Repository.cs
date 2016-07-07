
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace SuperShoes.Domain.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly IContext<T> context;

        public IContext<T> Context
        {
            get
            {
                return this.context;
            }
        }

        public Repository()
        {
            this.context = new Context<T>("superShoesEntities");
        }

        //public Repository(string connectionStringName)
        //{
        //    this.context = new Context<T>(connectionStringName);
        //}

        //public Repository(ObjectContext context, bool isMyContext)
        //{
        //    this.context = new Context<T>(context, isMyContext);
        //}

        public T Add(T entity)
        {
            return this.context.DbSet.Add(entity);
        }

        public T Delete(T entity)
        {
            return this.context.DbSet.Remove(entity);
        }

        public T PrepareUpdate(T entity)
        {
            var updated = this.context.DbSet.Attach(entity);
            return updated;
        }

        public void Update(T entity)
        {
            this.context.DbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

        }

        public IQueryable<T> GetAll()
        {
            return this.context.DbSet;
        }

        public IOrderedEnumerable<T> GetAll(Func<T, object> order)
        {
            return this.context.DbSet.OrderBy<T, object>(order);
        }

        public T Get(object key)
        {
            return this.context.DbSet.Find(key);
        }

        public void SaveChanges()
        {
            this.context.DbContext.SaveChanges();
        }

        public IEnumerable<T> GetSome(Func<T, bool> function)
        {
            return this.context.DbSet.Where<T>(function);
        }

        public IOrderedEnumerable<T> GetSome(Func<T, bool> function, Func<T, object> order)
        {
            return this.context.DbSet.Where<T>(function).OrderBy<T, object>(order);
        }

        public ObjectContext GetContext()
        {
            System.Data.Entity.Core.Objects.ObjectContext context = null;
            if (this.context.DbContext != null)
            {
                var adapter = (System.Data.Entity.Infrastructure.IObjectContextAdapter)this.context.DbContext;
                context = adapter.ObjectContext;
            }
            return context;
        }

    }
}
