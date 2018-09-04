using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.Services;

namespace TestTask.Controllers
{
    [Route("api/file")]
    public class FileController : Controller
    {
        private readonly IFileService fileService;

        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpGet]
        public List<FileModel> Get()
        {
            return fileService.GetFiles();
        }

        [HttpPost]
        public void Post([FromBody] FileModel file)
        {
            fileService.PostFile(file);
        }
    }
}
