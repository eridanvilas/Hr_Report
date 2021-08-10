using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Relatorio_Mensal_API.Application.Commands;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Controllers
{
    [ApiController]
    [Route("api/v1/file")]
    [EnableCors]
    public class FileReportController : ControllerBase
    {

        private readonly ILogger<FileReportController> _logger;
        private readonly IMediator _mediator;

        public FileReportController(ILogger<FileReportController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFile(IFormFile formFile)
        {
            var response = await _mediator.Send(new FileReaderCommand(formFile));
            return Ok(response);
        }
    }
}
