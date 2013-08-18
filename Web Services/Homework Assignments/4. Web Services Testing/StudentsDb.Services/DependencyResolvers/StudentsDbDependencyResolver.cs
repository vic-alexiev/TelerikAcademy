using StudentsDb.Data;
using StudentsDb.Repositories;
using StudentsDb.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http.Dependencies;

namespace StudentsDb.Services.DependencyResolvers
{
    public class StudentsDbDependencyResolver : IDependencyResolver
    {
        public IRepository Repository { get; set; }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(this.Repository);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(this.Repository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}