using MediatR;
using Microsoft.Extensions.Configuration;
using Relatorio_Mensal_API.Application.Commands;
using Relatorio_Mensal_API.Application.Response;
using Relatorio_Mensal_API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Application.Handlers
{
    public class FileReaderHandler : IRequestHandler<FileReaderCommand, FileReaderCommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public FileReaderHandler(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        public async Task<FileReaderCommandResponse> Handle(FileReaderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filesPath = _configuration.GetSection("PathFile").Value;

                if (request.File == null)
                    throw new Exception("Nenhum arquivo foi anexado..");

                var extension = Path.GetExtension(request.File.FileName);

                if (extension != ".csv")
                    throw new Exception("Arquivo nao é um formato .csv");

                if (request.File.Length > 0)
                {
                    var fullPath = filesPath + request.File.FileName;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await request.File.CopyToAsync(stream);
                    }

                    var hoursworkeds = new List<HoursWorked>();
                    var usuario = "";
                    var lines = File.ReadAllLines(fullPath);
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

                            usuario = values[0] != "" ? values[0] : usuario; 
 

                            hoursworkeds.Add(new HoursWorked
                                (usuario,
                                    Convert.ToDateTime(values[1]),
                                    values[2],
                                    values[3],
                                    values[4],
                                    values[5],
                                    values[7],
                                    null));
                        }

                    }

                    var months = new List<string>();
                    foreach (var item in hoursworkeds)
                    {
                        if (months.Where(x => x == item.Date.Value.ToString("MMMM")).Count() == 0)
                        {
                            var temp = item.Date.Value.ToString("MMMM");
                            months.Add(temp);
                        }
                    }

                    string jsonString = JsonSerializer.Serialize(hoursworkeds);
                    return await Task.FromResult(new FileReaderCommandResponse(jsonString));
                }
                else
                    return await Task.FromResult(new FileReaderCommandResponse("Ocorreu um erro inesperado"));
            }

            catch (Exception ex)
            {
                return await Task.FromResult(new FileReaderCommandResponse("Ocorreu um erro: " + ex.Message));
            }
        }
    }
}
