using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;
using sistemaDeTarefasT2m.IRepository;
using sistemaDeTarefasT2m.IService;
using sistemaDeTarefasT2m.Repository;

namespace sistemaDeTarefasT2m.Service
{
    public class UserService: IUserService
    {

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            Console.WriteLine("Usuários encontrados: " + users);

            if (users == null || !users.Any())
            {
                throw new ApplicationException("Nenhum Usuário encontrado");
            }

            return users.Select(user => new UserDto(
                    user.Id,
                    user.Nome,
                    user.Email,
                    user.Senha,
                    user.DataCadastro
         
                )).ToList();
        }

    }
    //    public async Task<User> GetUserByIdAsync(int id)
    //    {
    //        var users = await _userRepository.GetAllAsync();
    //        return users.FirstOrDefault(u => u.Id == id);
    //    }
    //    public async Task AddUserAsync(User user)
    //    {
    //        // Implementar lógica para adicionar usuário
    //        throw new NotImplementedException();
    //    }
    //    public async Task UpdateUserAsync(User user)
    //    {
    //        // Implementar lógica para atualizar usuário
    //        throw new NotImplementedException();
    //    }
    //    public async Task DeleteUserAsync(int id)
    //    {
    //        // Implementar lógica para deletar usuário
    //        throw new NotImplementedException();
    //    }

    //}
}

