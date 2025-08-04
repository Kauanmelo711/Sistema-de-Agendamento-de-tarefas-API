using sistemaDeTarefasT2m.Entity;

namespace sistemaDeTarefasT2m.DTO
{
    public record TarefasDto(
        string? Descricao,
        DateTime? DataCriacao,
        DateTime? DataConclusao,
        StatusEnum? Status
    )
    {
    }
}
