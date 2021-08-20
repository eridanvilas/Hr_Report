using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Repositories.HoursWorked.CreateRepository
{
    public interface ICreateRepository
    {
        public Task CreateAsync(Models.HoursWorked hoursWorked);
    }
}
