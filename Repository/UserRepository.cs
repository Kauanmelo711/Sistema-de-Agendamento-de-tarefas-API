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

        public async Task<User?> GetByEmailAndPasswordAsync(string email, string senha)
        {
            var sql = @"SELECT * FROM usuarios WHERE email = @email AND senha = @senha";
            using var connection = _dbConnection.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { email, senha });
        }

        public async Task AddUserAsync(User user)
        {
            var sql = @"INSERT INTO usuarios (nome, email, senha, datacadastro)
                VALUES (@Nome, @Email, @Senha, @DataCadastro)";
            using var connection = _dbConnection.GetConnection();
            await connection.ExecuteAsync(sql, user);
        }

    }
}
