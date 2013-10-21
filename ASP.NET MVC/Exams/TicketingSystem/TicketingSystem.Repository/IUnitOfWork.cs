using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSystem.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();

        IRepository<T> GetRepository<T>() where T : class;
    }
}
