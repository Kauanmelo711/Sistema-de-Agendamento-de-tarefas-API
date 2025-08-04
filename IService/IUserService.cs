using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;

namespace sistemaDeTarefasT2m.IService
{
    public interface IUserService
    {

        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<User> ValidateUserAsync(string email, string senha);
        Task<User> RegisterUserAsync(RegisterDto dto);
        //Task<User> GetUserByIdAsync(int id);
        //Task AddUserAsync(User user);
        //Task UpdateUserAsync(User user);
        //Task DeleteUserAsync(int id);
    }
}
