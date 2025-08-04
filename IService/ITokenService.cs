using sistemaDeTarefasT2m.Entity;

namespace sistemaDeTarefasT2m.Service
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
