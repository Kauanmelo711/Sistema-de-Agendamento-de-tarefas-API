using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;


namespace sistemaDeTarefasT2m.IRepository
{
    public interface ITarefasRepository
    {

        Task<IEnumerable<Tarefas>> GetAllTarefasAsync();
        //Task<TarefasDto> GetTarefaByIdAsync(int id);
        Task AddTarefaAsync(Tarefas tarefa);
        Task UpdateTarefaAsync(Tarefas tarefa);
        Task DeleteTarefaAsync(Tarefas tarefa);
        Task<Tarefas> GetTarefaByIdAsync(int id);
    }
}
