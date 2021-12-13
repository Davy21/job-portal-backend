using System;
using System.Collections.Generic;

namespace Randstad.JobApplication.Service.Models
{
    public class JobForm
    {
        public int ID { get; set; }
        public string FormId { get; set; }
        public string JobTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string YearsExperience { get; set; }
        public string PreferredLocation { get; set; }
        public string HearAboutVacancy { get; set; }
        public string NoticePeriod { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string SkillSets { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
}
