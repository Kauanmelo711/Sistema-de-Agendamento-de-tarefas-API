using Dapper;
using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;
using sistemaDeTarefasT2m.Infraestrutura.Data;
using sistemaDeTarefasT2m.IRepository;

namespace sistemaDeTarefasT2m.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgresConnection _dbConnection;

        public UserRepository(PostgresConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var query = "SELECT * FROM usuarios u "; 
            
            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.QueryAsync<User>(query);
            }
        }

    }
}
