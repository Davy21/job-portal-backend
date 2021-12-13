using System;
using Microsoft.EntityFrameworkCore;
using Randstad.JobApplication.Service.Models;

namespace Randstad.JobApplication.Service.Data
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions<JobContext> options) : base(options) {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobForm> JobForms { get; set; }
    }
}
