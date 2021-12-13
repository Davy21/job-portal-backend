using System;
using System.Threading.Tasks;
using Randstad.JobApplication.Service.Repositories.IRepositories;

namespace Randstad.JobApplication.Service.Repositories.IConfiguration
{
    public interface IUnitOfWork : IDisposable
    {
        IJobFormRepository JobForms { get; }
        IJobRepository Jobs { get; }
        Task CompleteAsync();
    }
}
