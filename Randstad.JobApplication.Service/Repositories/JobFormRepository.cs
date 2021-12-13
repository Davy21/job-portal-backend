using System;
using Randstad.JobApplication.Service.Data;
using Randstad.JobApplication.Service.Models;
using Randstad.JobApplication.Service.Repositories.IRepositories;

namespace Randstad.JobApplication.Service.Repositories
{
    public class JobFormRepository : GenericRepository<JobForm>, IJobFormRepository
    {
        public JobFormRepository(JobContext context):base(context)
        {
        }
    }
}
