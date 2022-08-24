using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;

namespace FileHelper.FileHelper
{
    public class FileTool : IFileTool
    {
        private readonly FileOptions FileOptions;

        public FileTool(IOptions<FileOptions> fileOptions)
        {
            FileOptions = fileOptions.Value;
        }

        public void Delete(string fileName)
        {
            string extension = GetExtensionToUpper(fileName);
            string fullPath = Path.Combine(FileOptions.BasePath, extension, fileName);

            if (File.Exists(fullPath)) File.Delete(fullPath);

        }

        public async Task UploadAsync(IFormFile file)
        {
            string extension = GetExtensionToUpper(file.FileName);              //File extension to upper
            string directory = Path.Combine(FileOptions.BasePath, extension);   //File location directory
            string fullPath = Path.Combine(directory, file.FileName);           //File fullpath

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }

        public string GetExtensionToUpper(string fileName)
        {
            return Path.GetExtension(fileName)
                        .Trim('.')
                        .ToUpper();
        }


    }
}
