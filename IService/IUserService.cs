using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;

namespace sistemaDeTarefasT2m.IService
{
    public interface IUserService
    {

        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<User> ValidateUserAsync(string email, string senha);
        Task<User> RegisterUserAsync(RegisterDto dto);
        Task<UserDto> GetUserByIdAsync(int id);
        Task UpdateUserAsync(int id, UserDto dto);
        Task DeleteUserAsync(int id);
    }
}
