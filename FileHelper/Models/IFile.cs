using Microsoft.AspNetCore.Http;

namespace FileHelper.Models
{
    public interface IFile:IFormFile
    {
        public string Extension { get; set; }
    }
}
