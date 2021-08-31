using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
                var listMonth = response.ToList().Where(x => x.Data.Month == month);
                var json = System.Text.Json.JsonSerializer.Serialize(listMonth);

                var dataTable = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                var lines = new List<string>();
                string[] columnNames = dataTable.Columns.Cast<DataColumn>().
                                                  Select(column => column.ColumnName).
                                                  ToArray();
                var header = string.Join(";", columnNames) + "\n";
                lines.Add(header);
                var valueLines = dataTable.AsEnumerable()
                                   .Select(row => string.Join(";", row.ItemArray)).ToArray();

                for (int i = 0; i < valueLines.Count(); i++)
                {
                    valueLines[i] += "\n";
                }

                lines.AddRange(valueLines);
                string monthName = listMonth.Select(x => x.Data).FirstOrDefault().ToString("MMMM");
                string yearName = listMonth.Select(x => x.Data).FirstOrDefault().ToString("yyyy");

                return File(Encoding.UTF8.GetBytes(string.Concat(lines)), "text/csv", "Relatorio " + monthName +" - " + yearName + ".csv");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
