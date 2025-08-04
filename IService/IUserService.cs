using sistemaDeTarefasT2m.DTO;

namespace sistemaDeTarefasT2m.IService
{
    public interface IUserService
    {

        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        //Task<User> GetUserByIdAsync(int id);
        //Task AddUserAsync(User user);
        //Task UpdateUserAsync(User user);
        //Task DeleteUserAsync(int id);
    }
}
