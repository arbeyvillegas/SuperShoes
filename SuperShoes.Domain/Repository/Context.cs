using System.Configuration;

namespace SuperShoes.Domain.Repository
{
    
    public class Context<T> : IContext<T> where T : class
    {
        public Context()
        {
            this.DbContext = new System.Data.Entity.DbContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            this.DbSet = DbContext.Set<T>();
        }

        public Context(string connectionStringName)
        {
            this.DbContext = new System.Data.Entity.DbContext(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString);
            this.DbSet = DbContext.Set<T>();
        }

        public Context(System.Data.Common.DbConnection conexion, bool isMyContext)
        {
            this.DbContext = new System.Data.Entity.DbContext(conexion, isMyContext);
            this.DbSet = DbContext.Set<T>();
        }

        public Context(System.Data.Entity.Core.Objects.ObjectContext context, bool isMyContext)
        {
            this.DbContext = new System.Data.Entity.DbContext(context, isMyContext);
            this.DbSet = DbContext.Set<T>();
        }

        public System.Data.Entity.DbContext DbContext
        {
            get;
            private set;
        }

        public System.Data.Entity.Core.Objects.ObjectContext ContextObject
        {
            get
            {
                System.Data.Entity.Core.Objects.ObjectContext context = null;
                if (this.DbContext != null)
                {
                    var adapter = (System.Data.Entity.Infrastructure.IObjectContextAdapter)this.DbContext;
                    context = adapter.ObjectContext;
                }
                return context;
            }
        }

        public System.Data.Entity.IDbSet<T> DbSet
        {
            get;
            private set;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
