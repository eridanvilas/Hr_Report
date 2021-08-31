using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        private readonly IGetByUserRepository _getByUserRepository;

        public GetByUserHandler(IMediator mediator, IConfiguration configuration, IGetByUserRepository getByUserRepository)
        {
            _mediator = mediator;
            _configuration = configuration;
            _getByUserRepository = getByUserRepository;
        }

        public async Task<File> Handle(GetByUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _getByUserRepository.GetAsync(request.Usuario);
            var listMonth = response.ToList().Where(x => x.Data.Month == request.Mes);
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
            var file = File(Encoding.UTF8.GetBytes(string.Concat(lines)),
                            "text/csv",
                            "Relatorio " + monthName + " - " + yearName + ".csv");

            return await Task.FromResult(file);
        }
    }
}
