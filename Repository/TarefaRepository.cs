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
        public async Task<Tarefas> GetTarefaByIdAsync(int id)
{
    var query = @"SELECT * FROM tarefas WHERE id = @Id";
    
    using (var connection = _dbConnection.GetConnection())
    {
        return await connection.QueryFirstOrDefaultAsync<Tarefas>(query, new { Id = id });
    }
}

public async Task UpdateTarefaAsync(Tarefas tarefa)
{
    var query = @"UPDATE tarefas 
                  SET descricao = @Descricao, 
                      dataconclusao = @DataConclusao, 
                      status = @Status::status_enum
                  WHERE id = @Id";

            var tarefaComStatusString = new
            {
                tarefa.Descricao,
                tarefa.Id,
                tarefa.DataConclusao,
                Status = tarefa.Status.ToString()
            };

            using (var connection = _dbConnection.GetConnection())
    {
        await connection.ExecuteAsync(query, tarefaComStatusString);
    }
}

public async Task DeleteTarefaAsync(Tarefas tarefa)
{
    var query = @"DELETE FROM tarefas WHERE id = @Id";

    using (var connection = _dbConnection.GetConnection())
    {
        await connection.ExecuteAsync(query, new { tarefa.Id });
    }
}

        }
}
