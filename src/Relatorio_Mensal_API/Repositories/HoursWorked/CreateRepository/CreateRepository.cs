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
                     Data,
                     HoraEntrada,
                     HoraSaida,
                     TotalHoras,
                     Projeto,
                     Descricao)
                VALUES
                    (@Usuario,
                     @Data,
                     @HoraEntrada,
                     @HoraSaida,
                     @TotalHoras,
                     @Projeto,
                     @Descricao);",
                new
                {
                    Usuario = hoursWorked.Usuario,
                    Data = hoursWorked.Data,
                    HoraEntrada= hoursWorked.HoraEntrada,
                    HoraSaida= hoursWorked.HoraSaida,
                    TotalHoras = hoursWorked.TotalHoras,
                    Projeto= hoursWorked.Projeto,
                    Descricao= hoursWorked.Descricao
                });
        }
    }
}
