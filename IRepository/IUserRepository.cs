using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;

namespace sistemaDeTarefasT2m.IRepository
{
    public interface IUserRepository
    {
        
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByEmailAndPasswordAsync(string email, string senha);
        Task AddUserAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<User> GetByEmailAsync(string email);
    }
}
