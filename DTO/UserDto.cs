namespace sistemaDeTarefasT2m.DTO
{
    public record  UserDto(
         int? Id,
        string? Nome,
        string? Email,
        string? Senha,
        DateTime? DataCadastro
        );

    }

