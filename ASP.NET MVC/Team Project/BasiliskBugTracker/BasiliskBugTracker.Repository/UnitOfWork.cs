using BasiliskBugTracker.Data;
using BasiliskBugTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasiliskBugTracker.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork()
            : this(new ApplicationDbContext())
        {
        }

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public int Save()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            return context.GetValidationErrors();
        }
    }
}
