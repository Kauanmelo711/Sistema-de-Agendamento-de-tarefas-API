using Dapper;
using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;
using sistemaDeTarefasT2m.Infraestrutura.Data;
using sistemaDeTarefasT2m.IRepository;

namespace sistemaDeTarefasT2m.Repository
{
    public class TarefaRepository : ITarefasRepository
    {
        private readonly PostgresConnection _dbConnection;

        public TarefaRepository(PostgresConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<Tarefas>> GetAllTarefasAsync()
        {
            var query = @"SELECT * FROM Tarefas t " +
                "join usuarios u ON u.\"Id\"  = t.userid";

            using (var connection = _dbConnection.GetConnection())
            {
                return await connection.QueryAsync<Tarefas>(query);
            }
        }
        public async Task AddTarefaAsync(Tarefas tarefa)
        {
            var query = @"INSERT INTO tarefas
            (descricao, datacriacao, dataconclusao, userid)
            VALUES(@Descricao, @DataCriacao, @DataConclusao, @UserId)
            RETURNING *;";

           
           

            using (var connection = _dbConnection.GetConnection())
            {
                 await connection.QueryAsync<Tarefas>(query, tarefa);
            }
        }

        }
}
