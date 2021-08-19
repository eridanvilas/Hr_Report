using Relatorio_Mensal_API.Repositories.Contrants;
using Relatorio_Mensal_API.Repositories.HoursWorked.CreateRepository;
using Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Repositories
{
    public class HoursWorkedRepository : IHoursWorkedRepository
    {
        private readonly IGetByUserRepository _getByUserRepository;
        private readonly ICreateRepository _createRepository;

        public HoursWorkedRepository(IGetByUserRepository getByUserRepository, ICreateRepository createRepository)
        {
            _getByUserRepository = getByUserRepository;
            _createRepository = createRepository;
        }

        public async Task CreateAsync(Models.HoursWorked hoursWorked) => await _createRepository.CreateAsync(hoursWorked);

        public async Task<IEnumerable<Models.HoursWorked>> GetAsync(string user) => await _getByUserRepository.GetAsync(user);
    }

}
