using Microsoft.AspNetCore.Http;

namespace FileHelper.FileHelper
{
    public interface IFileTool
    {
        void Upload(IFormFile file);
    }
}