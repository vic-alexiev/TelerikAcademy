using StudentsDb.Models;
using StudentsDb.Repositories;
using System.Collections.Generic;
using System.Data;
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

        // GET api/<controller>
        public IEnumerable<T> Get<T>()
            where T : class
        {
            return DataStore.All<T>(Includes);
        }

        // GET api/<controller>/5
        public T Get<T>(int id)
            where T : class, IIdentifier
        {
            return DataStore.Find<T>(t => t.Id == id, Includes);
        }

        // POST api/<controller>
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

        // PUT api/<controller>
        public void Put<T>([FromBody]T value)
            where T : class
        {
            DataStore.Update<T>(value);
        }

        // DELETE api/<controller>/5
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
    }
}
