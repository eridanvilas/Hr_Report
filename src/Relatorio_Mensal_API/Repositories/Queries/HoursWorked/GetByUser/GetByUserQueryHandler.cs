using MediatR;
using Relatorio_Mensal_API.Repositories.Contrants;
using System.Threading;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser
{
    public class GetByUserQueryHandler : IRequestHandler<GetByUserQuery, GetByUserQueryResponse>
    {
        private readonly IHoursWorkedRepository _hoursWorkedRepository;

        public GetByUserQueryHandler(IHoursWorkedRepository hoursWorkedRepository) =>
            (_hoursWorkedRepository) = (hoursWorkedRepository);

        public async Task<GetByUserQueryResponse> Handle(GetByUserQuery request, CancellationToken cancellationToken)
        {
            var response = new GetByUserQueryResponse((Models.HoursWorked)await _hoursWorkedRepository.GetAsync(request.HoursWorked.Usuario));

            return response;
        }
    }
}

