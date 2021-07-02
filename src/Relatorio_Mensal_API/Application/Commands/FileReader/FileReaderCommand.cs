using MediatR;
using Microsoft.AspNetCore.Http;
using Relatorio_Mensal_API.Application.Response;

namespace Relatorio_Mensal_API.Application.Commands
{
    public class FileReaderCommand : IRequest<FileReaderCommandResponse>
    { 
        public IFormFile File { get; set; }
        public FileReaderCommand(IFormFile file) => File = file;
    }
}
