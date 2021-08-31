using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAll();

        Task Create(T obj);
    }
}