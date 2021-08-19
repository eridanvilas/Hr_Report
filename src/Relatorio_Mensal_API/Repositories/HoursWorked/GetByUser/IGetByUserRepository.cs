using System.Collections.Generic;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser
{
    public interface IGetByUserRepository
    {
        Task<IEnumerable<Models.HoursWorked>> GetAsync(string user);
    }
}
