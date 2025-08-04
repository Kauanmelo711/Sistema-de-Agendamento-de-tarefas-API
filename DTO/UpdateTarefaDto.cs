using sistemaDeTarefasT2m.Entity;

namespace sistemaDeTarefasT2m.DTO
{
    public class UpdateTarefaDto
    {
        public string Descricao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public StatusEnum Status { get; set; }
    }
}
