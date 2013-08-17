using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace StudentsDb.Repositories
{
    /// <summary>
    /// http://blog.falafel.com/blogs/basem-emara/2013/02/05/generic-repository-pattern-with-entity-framework-and-web-api
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Gets all objects from database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> All<T>(string[] includes = null) where T : class;

        /// <summary>
        /// Select Single Item by specified expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        T Get<T>(Expression<Func<T, bool>> expression, string[] includes = null) where T : class;

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        T Find<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class;

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">Specified a filter</param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate, string[] includes = null) where T : class;

        /// <summary>
        /// Gets objects from database with filtering and paging.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">Specified a filter</param>
        /// <param name="total">Returns the total records count of the filter.</param>
        /// <param name="index">Specified the page index.</param>
        /// <param name="size">Specified the page size</param>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50, string[] includes = null) where T : class;

        /// <summary>
        /// Checks if the object(s) exists in database by specified filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">Specified the filter expression</param>
        /// <returns></returns>
        bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">Specified a new object to create.</param>
        /// <returns></returns>
        T Create<T>(T t) where T : class;

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specifies an existing object to delete.</param>
        int Delete<T>(T t) where T : class;

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Delete<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">Specified the object to save.</param>
        /// <returns></returns>
        int Update<T>(T t) where T : class;
    }
}
