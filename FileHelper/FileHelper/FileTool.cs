using Microsoft.AspNetCore.Http;
using System.IO;

namespace FileHelper.FileHelper
{
    public class FileTool : IFileTool
    {
        public void Upload(IFormFile file)
        {
            string basePath = "wwwroot/files/";
            string extension=Path.GetExtension(file.FileName).Trim('.');
            string directory = Path.Combine(basePath, extension);
            string fullPath = Path.Combine(directory,file.FileName);

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
    }
}
