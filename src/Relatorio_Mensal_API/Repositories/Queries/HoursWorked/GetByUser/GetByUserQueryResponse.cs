namespace Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser
{
    public class GetByUserQueryResponse
    {
        public GetByUserQueryResponse(Models.HoursWorked hoursWorked) => HoursWorked = hoursWorked;

        public Models.HoursWorked HoursWorked;
    }
}
