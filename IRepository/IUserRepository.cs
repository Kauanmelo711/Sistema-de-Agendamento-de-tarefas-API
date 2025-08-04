using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;

namespace sistemaDeTarefasT2m.IRepository
{
    public interface IUserRepository
    {
        
        Task<IEnumerable<User>> GetAllAsync();
        //Task<User> GetByIdAsync(int id);
        //Task AddAsync(User user);
        //Task UpdateAsync(User user);
        //Task DeleteAsync(int id);

    }
}
