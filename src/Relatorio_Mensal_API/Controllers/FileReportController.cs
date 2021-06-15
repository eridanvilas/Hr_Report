using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Relatorio_Mensal_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileReportController : ControllerBase
    {

        private readonly ILogger<FileReportController> _logger;

        public FileReportController(ILogger<FileReportController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                var filesPath = Directory.GetCurrentDirectory();

                var extension = Path.GetExtension(file.FileName);

                if (extension != ".csv")
                    throw new Exception("Arquivo nao é um formato .csv");

                if (file.Length > 0)
                {
                    var fullPath = Path.GetFullPath(file.FileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var hoursworkeds = new List<HoursWorked>();

                    var lines = System.IO.File.ReadAllLines(fullPath);
                    foreach (string line in lines)
                    {
                        if (line != lines[0])
                        {
                            int nNull = 0;
                            var values = line.Split(';');
                            foreach (var item in values)
                            {
                                if (item == "")
                                    nNull++;
                            }

                            if (nNull > 1)
                                continue;

                            hoursworkeds.Add(new HoursWorked
                                (values[0],
                                    Convert.ToDateTime(values[1]),
                                    TimeSpan.Parse(values[2]),
                                    TimeSpan.Parse(values[3]),
                                    TimeSpan.Parse(values[4]),
                                    TimeSpan.Parse(values[5]),
                                    TimeSpan.Parse(values[7]),
                                    ""));
                        }

                    }

                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }
    }
}
