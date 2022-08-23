using Microsoft.AspNetCore.Http;
using System.IO;

namespace FileHelper.FileHelper
{
    public class FileTool :IFileTool
    {
        public  void Upload(IFormFile file)
        {
            Directory.CreateDirectory("wwwroot/files");
            using (var fileStream=new FileStream("wwwroot/files/"+file.FileName,FileMode.Create))
            {
                 file.CopyTo(fileStream);
            }
        }
    }
}
