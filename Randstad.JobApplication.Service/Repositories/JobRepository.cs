using System;
using Randstad.JobApplication.Service.Data;
using Randstad.JobApplication.Service.Models;
using Randstad.JobApplication.Service.Repositories.IRepositories;

namespace Randstad.JobApplication.Service.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(JobContext context):base(context) {

        }


    }
}
