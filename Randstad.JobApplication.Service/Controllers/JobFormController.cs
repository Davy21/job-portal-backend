using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Randstad.JobApplication.Service.Models;
using Randstad.JobApplication.Service.Repositories.IConfiguration;

namespace Randstad.JobApplication.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobFormController : ControllerBase
    {
        IUnitOfWork _unit;

        public JobFormController(IUnitOfWork unit) {
            _unit = unit;
        }

        [HttpGet]
        public async Task<IEnumerable> All()
        {
            return await _unit.JobForms.All();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobForm>> GetById(int id)
        {
            var jobForm = await _unit.JobForms.GetById(id);

            if (jobForm == null)
            {
                return NotFound();
            }

            return jobForm;
        }

        [HttpPost]
        public async Task<ActionResult<JobForm>> Add(JobForm jobform)
        {
            jobform.SubmittedDate = DateTime.Now;
            await _unit.JobForms.Add(jobform);
            await _unit.CompleteAsync();

            return CreatedAtAction(nameof(Add), new { id = jobform.ID }, jobform);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<JobForm>> Delete(int id)
        {
            var jobform = await _unit.JobForms.GetById(id);
            if (jobform == null)
            {
                return NotFound();
            }

            _unit.JobForms.Delete(jobform);
            await _unit.CompleteAsync();

            return jobform;
        }
    }
}
