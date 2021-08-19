using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Relatorio_Mensal_API.Repositories.HoursWorked.CreateRepository
{
    public class CreateRepository : ICreateRepository
    {
        private readonly IConfiguration _configuration;

        public CreateRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        private string Connection => _configuration.GetConnectionString("DefaultConnection");

        public async Task CreateAsync(Models.HoursWorked hoursWorked)
        {
            using var connection = new SqliteConnection(Connection);
            connection.Open();

            await connection.ExecuteAsync(
                @"INSERT INTO HoursWorked
                    (Usuario,
                     Date,
                     HoraEntrada,
                     HoraSaida,
                     HoraRetorno,
                     HoraFinal,
                     TotalHoras,
                     Descricao)
                VALUES
                    (@Usuario,
                     @Date,
                     @HoraEntrada,
                     @HoraSaida,
                     @HoraRetorno,
                     @HoraFinal,
                     @TotalHoras,
                     @Descricao);",
                new
                {
                    Usuario = hoursWorked.Usuario,
                    Date = hoursWorked.Date,
                    HoraEntrada= hoursWorked.HoraEntrada,
                    HoraSaida= hoursWorked.HoraSaida,
                    HoraRetorno= hoursWorked.HoraRetorno,
                    HoraFinal= hoursWorked.HoraFinal,
                    TotalHoras= hoursWorked.TotalHoras,
                    Descricao= hoursWorked.Descricao
                });
        }
    }
}
