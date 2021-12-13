using System;
namespace Randstad.JobApplication.Service.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string JobTitle { get; set; }
        public string JobDepartment { get; set; }
        public string JobLocation { get; set; }
        public string JobSalary { get; set; }
        public string JobDesc { get; set; }
        public bool IsValid { get; set; }
    }
}
