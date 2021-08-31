using MediatR;
using System;

namespace Relatorio_Mensal_API.Application.Commands.GetByUser
{
    public class GetByUserCommand : IRequest<GetByUserCommandResponse>
    {
        public string Usuario { get; set; }
        public int Mes { get; set; }
        public GetByUserCommand(string usuario, int mes) => (Usuario, Mes) = (usuario, mes);
    }
}
