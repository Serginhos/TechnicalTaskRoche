using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocheTechnicalTask.Application;
using RocheTechnicalTask.Entities;
using RocheTechnicalTask.Repository;

namespace RocheTechnicalTask.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        //IApplication<TextFilesSummary> _summary;
        IApplication<TextFile> _textFiles;

        public FilesController(IApplication<TextFile> textFiles)
        {
            _textFiles = textFiles;
        }

        [HttpGet]
        public IActionResult Get(string sText)
        {
            string sDir = Environment.CurrentDirectory;
            List<TextFile> textFiles = FileRepository.GetTextFilesFromDir(sDir, sText);


            return Ok(textFiles);
        }


    }
}
