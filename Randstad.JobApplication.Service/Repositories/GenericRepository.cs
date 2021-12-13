using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Randstad.JobApplication.Service.Data;
using Randstad.JobApplication.Service.Repositories.IRepositories;

namespace Randstad.JobApplication.Service.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal JobContext context;
        internal DbSet<T> dbSet;

        public GenericRepository(JobContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task<IEnumerable> All()
        {
            return await dbSet.ToListAsync();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
