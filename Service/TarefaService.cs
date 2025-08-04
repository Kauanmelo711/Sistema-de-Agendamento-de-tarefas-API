using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;
using sistemaDeTarefasT2m.IRepository;
using sistemaDeTarefasT2m.IService;

namespace sistemaDeTarefasT2m.Service
{
    public class TarefaService : ITarefasService
    {
        private readonly ITarefasRepository _tarefaRepository;
        public TarefaService(ITarefasRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task<IEnumerable<TarefasDto>> GetAllTarefasByUserId()
        {
            var tarefas = await _tarefaRepository.GetAllTarefasAsync();
            
            return tarefas.Select(tarefas => new TarefasDto(
                tarefas.Descricao,
                tarefas.DataCriacao,
                tarefas.DataConclusao,
                tarefas.Status
                )).ToList();
        }
        public async Task AddTarefaAsync(CreateTarefaDto tarefa)
        {
            Tarefas tarefaEntity = new Tarefas
            {
                Descricao = tarefa.Descricao,
                DataConclusao = tarefa.DataConclusao,
                UserId = 1,
            };
                 await _tarefaRepository.AddTarefaAsync(tarefaEntity );
            
        }
    }
}
