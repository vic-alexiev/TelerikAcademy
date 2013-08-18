using StudentsDb.Data;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace StudentsDb.Repositories
{
    public class StudentsDbRepository : IRepository
    {
        private DbContext dbContext;

        public StudentsDbRepository()
            : this(new StudentsDbContext())
        {
        }

        public StudentsDbRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;

            //SERIALIZE WILL FAIL WITH PROXIED ENTITIES
            dbContext.Configuration.ProxyCreationEnabled = false;

            //ENABLING COULD CAUSE ENDLESS LOOPS AND PERFORMANCE PROBLEMS
            dbContext.Configuration.LazyLoadingEnabled = false;
        }

        public IQueryable<T> All<T>(string[] includes = null) where T : class
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return dbContext.Set<T>().AsQueryable();
        }

        public T Get<T>(Expression<Func<T, bool>> expression, string[] includes = null) where T : class
        {
            return this.All<T>(includes).FirstOrDefault(expression);
        }

        public T Find<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault<T>(predicate);
            }

            return dbContext.Set<T>().FirstOrDefault<T>(predicate);
        }

        public IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).AsQueryable<T>();
            }

            return dbContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null) where T : class
        {
            int skipCount = index * size;
            IQueryable<T> resultSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                resultSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                resultSet = predicate != null ? dbContext.Set<T>().Where<T>(predicate).AsQueryable() : dbContext.Set<T>().AsQueryable();
            }

            resultSet = skipCount == 0 ? resultSet.Take(size) : resultSet.Skip(skipCount).Take(size);
            total = resultSet.Count();
            return resultSet.AsQueryable();
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return dbContext.Set<T>().Count<T>(predicate) > 0;
        }

        public T Create<T>(T t) where T : class
        {
            var newEntry = dbContext.Set<T>().Add(t);
            dbContext.SaveChanges();
            return newEntry;
        }

        public int Delete<T>(T t) where T : class
        {
            dbContext.Set<T>().Remove(t);
            return dbContext.SaveChanges();
        }

        public int Delete<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var objects = this.Filter<T>(predicate);
            foreach (var obj in objects)
                dbContext.Set<T>().Remove(obj);
            return dbContext.SaveChanges();
        }

        public int Update<T>(T t) where T : class
        {
            var entry = dbContext.Entry(t);
            dbContext.Set<T>().Attach(t);
            entry.State = EntityState.Modified;
            return dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (this.dbContext != null)
            {
                this.dbContext.Dispose();
            }
        }
    }
}
