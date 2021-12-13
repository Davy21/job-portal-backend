using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Randstad.JobApplication.Service.Services.IServices
{
    public interface IUploadFileService
    {
        Task<bool> UploadFileAsync(IFormFile file, string fileName);
    }
}
