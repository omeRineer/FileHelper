using FileHelper.FileHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        public IActionResult Upload(IFormFileCollection files)
        {
            foreach (var file in files)
            {
                _fileTool.Upload(file);
            }
            return Ok();
        }
    }
}
