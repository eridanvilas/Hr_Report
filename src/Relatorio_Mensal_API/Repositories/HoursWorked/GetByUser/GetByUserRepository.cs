using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Repositories.HoursWorked.GetByUser
{
    public class GetByUserRepository : IGetByUserRepository
    {
        private readonly IConfiguration _configuration;

        public GetByUserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string Connection => _configuration.GetConnectionString("DefaultConnection");
        public async Task<IList<Models.HoursWorked>> GetAsync(string user)
        {
            using var connection = new SqliteConnection(Connection);
            return (IList<Models.HoursWorked>)await connection.QueryAsync<Models.HoursWorked>(
                sql: @"SELECT USUARIO,
	                            DATA,
		                        HORAENTRADA,
		                        HORASAIDA,
		                        TOTALHORAS,
		                        PROJETO,
		                        DESCRICAO
	                     FROM HoursWorked
                         WHERE USUARIO =@User",
                param: new { User = user }
                );
        }
    }
}
