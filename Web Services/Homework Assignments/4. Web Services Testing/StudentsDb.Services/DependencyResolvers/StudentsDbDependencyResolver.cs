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
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(StudentsController))
            {
                DbContext studentsDbContext = new StudentsDbContext();
                IRepository repository = new StudentsDbRepository(studentsDbContext);
                return new StudentsController(repository);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                DbContext studentsDbContext = new StudentsDbContext();
                IRepository repository = new StudentsDbRepository(studentsDbContext);
                return new SchoolsController(repository);
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