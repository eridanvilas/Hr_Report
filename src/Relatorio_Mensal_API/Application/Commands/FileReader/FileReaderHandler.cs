using MediatR;
using Microsoft.Extensions.Configuration;
using Relatorio_Mensal_API.Application.Commands;
using Relatorio_Mensal_API.Application.Response;
using Relatorio_Mensal_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                    return await Task.FromResult(new FileReaderCommandResponse("Arquivo Lido com sucesso!"));
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
