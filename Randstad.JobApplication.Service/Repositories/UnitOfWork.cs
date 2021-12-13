using System;
using System.Threading.Tasks;
using Randstad.JobApplication.Service.Data;
using Randstad.JobApplication.Service.Repositories.IConfiguration;
using Randstad.JobApplication.Service.Repositories.IRepositories;

namespace Randstad.JobApplication.Service.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        JobContext _context;

        public UnitOfWork(JobContext context)
        {
            _context = context;
            Jobs = new JobRepository(_context);
            JobForms = new JobFormRepository(_context);
        }

        public IJobRepository Jobs { get; private set; }

        public IJobFormRepository JobForms { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
