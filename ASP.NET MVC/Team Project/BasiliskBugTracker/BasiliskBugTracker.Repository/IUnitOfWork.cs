using BasiliskBugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasiliskBugTracker.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();

        IRepository<T> GetRepository<T>() where T : class;
    }
}
