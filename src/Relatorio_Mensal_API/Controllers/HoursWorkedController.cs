using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Controllers
{
    [ApiController]
    [Route("api/v1/hoursworked")]
    [EnableCors]
    public class HoursWorkedController : Controller
    {

        private readonly IGetByUserRepository _getByUserRepository;

        public HoursWorkedController(IGetByUserRepository getByUserRepository)
        {
            _getByUserRepository = getByUserRepository;
        }

        [HttpGet("GetHoursMonthByUsuario")]
        public async Task<IActionResult> GetHoursMonthByUsuario(string usuario, int month)
        {
            try
            {
                var response = await _getByUserRepository.GetAsync(usuario);
                var listMonth = response.ToList().Where(x => x.Data.Value.Month == month);
                return Ok(listMonth);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
