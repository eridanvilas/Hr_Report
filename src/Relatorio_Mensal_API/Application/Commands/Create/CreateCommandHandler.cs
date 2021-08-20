using MediatR;
using Relatorio_Mensal_API.Repositories.Contrants;
using System.Threading;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Application.Commands.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, Unit>
    {
        private readonly IHoursWorkedRepository _hoursWorkedRepository;

        public CreateCommandHandler(IHoursWorkedRepository hoursWorkedRepository) =>
            (_hoursWorkedRepository) = (hoursWorkedRepository);

        public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
        { 
           await _hoursWorkedRepository.CreateAsync(request.HoursWorked);
           return Unit.Value;
        }
    }
}
