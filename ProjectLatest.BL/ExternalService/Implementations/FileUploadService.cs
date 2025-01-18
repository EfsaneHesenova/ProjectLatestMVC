using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjectLatest.BL.ExternalService.Abstractions;

namespace ProjectLatest.BL.ExternalService.Implementations
{
    public class FileUploadService : IFileUploadService
    {
        public void DeleteFile(string FileNameWithExtensions, string envPath)
        {
            if (!string.IsNullOrEmpty(FileNameWithExtensions))
            {
                throw new ArgumentNullException(nameof(FileNameWithExtensions));
            }
            var path = Path.Combine(envPath, "uploads", FileNameWithExtensions);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            File.Delete(path);

        }

        public async Task<string> FileUploadAsync(IFormFile file, string envPath, string[] allowedExtensions)
        {
            if(file is null) {  throw new ArgumentNullException(nameof(file)); }
            var contentPath = Path.Combine(envPath, "uploads");
            if (!File.Exists(contentPath))
            {
                Directory.CreateDirectory(contentPath);
            }
            var ext = Path.GetExtension(file.FileName).ToLower();
            if(!allowedExtensions.Contains(ext))
            {
                throw new ArgumentException();
            }
            var fileName = $"{Guid.NewGuid()}{ext}";
            var path = Path.Combine(contentPath, fileName);
            using FileStream fileStream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return fileName;
        }
    }
}
