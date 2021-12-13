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
    public class JobController : ControllerBase
    {
        IUnitOfWork _unit;

        public JobController(IUnitOfWork unit) {
            _unit = unit;
        }

        [HttpGet]
        public async Task<IEnumerable> All()
        {
            return await _unit.Jobs.All();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetById(int id)
        {
            var job = await _unit.Jobs.GetById(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        [HttpPost]
        public async Task<ActionResult<Job>> Add(Job job)
        {
            await _unit.Jobs.Add(job);
            await _unit.CompleteAsync();

            return CreatedAtAction(nameof(Add), new { id = job.ID }, job);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Job>> Delete(int id)
        {
            var job = await _unit.Jobs.GetById(id);
            if (job == null)
            {
                return NotFound();
            }

            _unit.Jobs.Delete(job);
            await _unit.CompleteAsync();

            return job;
        }
    }
}
