using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Relatorio_Mensal_API.Models;
using Relatorio_Mensal_API.Repositories.Contrants;
using Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Application.Commands.GetByUser
{
    public class GetByUserHandler : IRequestHandler<GetByUserCommand, GetByUserCommandResponse>
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IHoursWorkedRepository _hoursWorkedRepository;

        public GetByUserHandler(IMediator mediator, IConfiguration configuration, IHoursWorkedRepository hoursWorkedRepository)
        {
            _mediator = mediator;
            _configuration = configuration;
            _hoursWorkedRepository = hoursWorkedRepository;
        }

        public async Task<GetByUserCommandResponse> Handle(GetByUserCommand request, CancellationToken cancellationToken)
        {
            IList<HoursWorked> hoursWorked = (IList<HoursWorked>)await _hoursWorkedRepository.GetAsync(request.Usuario);
            var listMonth = hoursWorked.ToList().Where(x => x.Data.Month == request.Mes).ToList();

            var response = new GetByUserCommandResponse(listMonth);
            return response;
        }
    }
}
