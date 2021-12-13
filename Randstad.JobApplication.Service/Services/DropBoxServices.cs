using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Randstad.JobApplication.Service.Services.IServices;

namespace Randstad.JobApplication.Service.Services
{
    public class DropBoxServices : IUploadFileService
    {
        IConfiguration _config;

        public DropBoxServices(IConfiguration config) {
            _config = config;
        }

        public async Task<bool> UploadFileAsync(IFormFile file, string fileName)
        {
            try
            {
                string token = _config.GetValue<string>("DropBoxToken");
                string dropboxFolder = _config.GetValue<string>("DropBoxFolder");
                
                DropboxClient client = new DropboxClient(token);

                using (var mem = new MemoryStream())
                {
                    file.CopyTo(mem);
                    mem.Position = 0;
                    var updated = await client.Files.UploadAsync(
                        dropboxFolder + "/" + fileName,
                        WriteMode.Overwrite.Instance,
                        body: mem);
                }

                return true;
            }
            catch(Exception ex) {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }
    }
}
