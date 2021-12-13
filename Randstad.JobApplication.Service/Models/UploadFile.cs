using System;
using Microsoft.AspNetCore.Http;

namespace Randstad.JobApplication.Service.Models
{
    public class UploadFile
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
    }
}
