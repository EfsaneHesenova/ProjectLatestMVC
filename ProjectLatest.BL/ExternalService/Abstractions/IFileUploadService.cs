using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectLatest.BL.ExternalService.Abstractions
{
    public interface IFileUploadService
    {
        Task<string> FileUploadAsync(IFormFile file, string envPath, string[] allowedExtensions);
        public void DeleteFile(string FileNameWithExtensions, string envPath);
    }
}
