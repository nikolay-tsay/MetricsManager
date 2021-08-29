using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetricsManager.DAL.Services.Interfaces
{
    public interface IServiceBase<T> where T : class
    {
        Task<IList<T>> GetAll();
    }
}