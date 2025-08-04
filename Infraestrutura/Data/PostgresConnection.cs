using System.Data;
using Npgsql;

namespace sistemaDeTarefasT2m.Infraestrutura.Data
{
    public class PostgresConnection
    {
        private readonly string _connectionString;

        public PostgresConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}