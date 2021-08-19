using MediatR;

namespace Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser
{
    public class GetByUserQuery : IRequest<GetByUserQueryResponse>
    {
        public GetByUserQuery(Models.HoursWorked hoursWorked) =>
            (HoursWorked) = (hoursWorked);

        public Models.HoursWorked HoursWorked { get; set; }
    }
}
