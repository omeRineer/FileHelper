using FileHelper.FileHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FileHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileTool _fileTool;

        public FileUploadController(IFileTool fileTool)
        {
            _fileTool = fileTool;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFileCollection files)
        {
            foreach (var file in files)
            {
                await _fileTool.UploadAsync(file);
            }
            return Ok();
        }

        [HttpGet("{fileName}")]
        public IActionResult Delete(string fileName)
        {
            _fileTool.Delete(fileName);
            return Ok();
        }
    }
}
