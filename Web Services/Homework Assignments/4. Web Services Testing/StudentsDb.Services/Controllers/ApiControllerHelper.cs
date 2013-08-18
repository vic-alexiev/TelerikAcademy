using StudentsDb.Models;
using StudentsDb.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Web.Http;

namespace StudentsDb.Services.Controllers
{
    public class ApiControllerHelper
    {
        public IRepository DataStore { get; private set; }
        public string[] Includes { get; private set; }

        public ApiControllerHelper(IRepository dataStore, string[] includes)
        {
            this.DataStore = dataStore;
            this.Includes = includes;
        }

        public IEnumerable<T> Get<T>()
            where T : class
        {
            return DataStore.All<T>(Includes);
        }

        public IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate)
            where T : class
        {
            return DataStore.Filter<T>(predicate, Includes);
        }

        public T Get<T>(int id)
            where T : class, IIdentifier
        {
            return DataStore.Find<T>(t => t.Id == id, Includes);
        }

        public void Post<T>([FromBody]T value)
            where T : class
        {
            try
            {
                DataStore.Create<T>(value);
            }
            catch (OptimisticConcurrencyException ex)
            {
                throw ex;
            }
        }

        public void Put<T>([FromBody]T value)
            where T : class
        {
            DataStore.Update<T>(value);
        }

        public void Delete<T>(int id)
            where T : class, IIdentifier
        {
            DataStore.Delete<T>(t => t.Id == id);
        }

        public void Delete<T>([FromBody]T value)
            where T : class, IIdentifier
        {
            Delete<T>(value.Id);
        }

        public string GetHeaderValue(HttpRequestHeaders headers, string key)
        {
            IEnumerable<string> values;

            if (headers.TryGetValues(key, out values))
            {
                return values.FirstOrDefault();
            }

            return null;
        }
    }
}
