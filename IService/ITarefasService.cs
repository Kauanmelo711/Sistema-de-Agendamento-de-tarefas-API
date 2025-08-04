using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;

namespace sistemaDeTarefasT2m.IService
{
    public  interface ITarefasService
    {
        
        Task<IEnumerable<TarefasDto>> GetAllTarefasByUserId();
        //Task<TarefaDto> GetTarefaByIdAsync(int id);
        Task AddTarefaAsync(CreateTarefaDto tarefa);
        //Task UpdateTarefaAsync(TarefaDto tarefa);
        //Task DeleteTarefaAsync(int id);

    }
}
