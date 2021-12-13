using System;
using System.Collections;
using System.Threading.Tasks;

namespace Randstad.JobApplication.Service.Repositories.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable> All();
        Task<T> GetById(object id);
        Task Add(T entity);
        void Delete(T entity);
    }
}
