using MediatR;
using Relatorio_Mensal_API.Application.Handlers;

namespace Relatorio_Mensal_API.Application.Response
{
    public class FileReaderCommandResponse
    {
        public string Result { get; set; }
        public FileReaderCommandResponse(string result) => Result = result;
    }
}
