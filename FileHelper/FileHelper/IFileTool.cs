using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FileHelper.FileHelper
{
    public interface IFileTool
    {
        Task UploadAsync(IFormFile file);
        void Delete(string filePath);
    }
}