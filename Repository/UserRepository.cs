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

        public async Task<User?> GetByEmailAsync(string email)
        {
            var sql = @"SELECT * FROM usuarios WHERE email = @email";
            using var connection = _dbConnection.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { email });
        }

        public async Task AddUserAsync(User user)
        {
            var sql = @"INSERT INTO usuarios (nome, email, senha, datacadastro)
                VALUES (@Nome, @Email, @Senha, @DataCadastro)";
            using var connection = _dbConnection.GetConnection();
            await connection.ExecuteAsync(sql, user);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var sql = @"SELECT * FROM usuarios WHERE id = @id";
            using var connection = _dbConnection.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<User>(sql, new { id });
        }

        public async Task UpdateAsync(User user)
        {
            var sql = @"UPDATE usuarios 
                SET nome = @Nome, email = @Email, senha = @Senha
                WHERE id = @Id";
            using var connection = _dbConnection.GetConnection();
            await connection.ExecuteAsync(sql, user);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = @"DELETE FROM usuarios WHERE id = @id";
            using var connection = _dbConnection.GetConnection();
            await connection.ExecuteAsync(sql, new { id });
        }

        public Task<User> GetByEmailAndPasswordAsync(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
