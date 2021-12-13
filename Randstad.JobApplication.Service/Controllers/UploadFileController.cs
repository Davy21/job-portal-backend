using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Randstad.JobApplication.Service.Models;
using Randstad.JobApplication.Service.Services.IServices;

namespace Randstad.JobApplication.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadFileController : ControllerBase
    {
        IUploadFileService _fileService;

        public UploadFileController(IUploadFileService fileService) {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Upload([FromForm]UploadFile file)
        {
 
            if (!await _fileService.UploadFileAsync(file.File,file.FileName)){
                return StatusCode(500, false);
            }            

            return CreatedAtAction(nameof(Upload), true);
        }
    }
}
