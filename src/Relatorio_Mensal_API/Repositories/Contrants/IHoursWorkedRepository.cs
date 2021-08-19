using System.Collections.Generic;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Repositories.Contrants
{
    public interface IHoursWorkedRepository
    {
        public Task CreateAsync(Models.HoursWorked hoursWorked);
        Task<IEnumerable<Models.HoursWorked>> GetAsync(string user);
    }
}
