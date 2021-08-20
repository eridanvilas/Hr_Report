using MediatR;
using Relatorio_Mensal_API.Models;

namespace Relatorio_Mensal_API.Application.Commands.Create
{
    public class CreateCommand: IRequest<Unit>
    {
        public CreateCommand(HoursWorked hoursWorked) => (HoursWorked) = (hoursWorked);
        public HoursWorked HoursWorked { get; set; }
    }
}
