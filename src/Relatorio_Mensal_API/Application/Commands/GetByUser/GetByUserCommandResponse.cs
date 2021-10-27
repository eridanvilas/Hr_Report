using Relatorio_Mensal_API.Models;
using System.Collections.Generic;

namespace Relatorio_Mensal_API.Application.Commands.GetByUser
{
    public class GetByUserCommandResponse
    {
        public IList<HoursWorked> HoursWorkeds;

        public GetByUserCommandResponse(IList<HoursWorked> hoursWorkeds)
        {
            HoursWorkeds = hoursWorkeds;
        }
    }
}
