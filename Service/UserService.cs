using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;
using sistemaDeTarefasT2m.IRepository;
using sistemaDeTarefasT2m.IService;
using sistemaDeTarefasT2m.Repository;

namespace sistemaDeTarefasT2m.Service
{
    public class UserService : IUserService
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
    
    public async Task<User> ValidateUserAsync(string email, string senha)
        {
            return await _userRepository.GetByEmailAndPasswordAsync(email, senha);
        }
        public async Task<User> RegisterUserAsync(RegisterDto dto)
        {
            var newUser = new User
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = dto.Senha,
                DataCadastro = DateTime.UtcNow
            };

            await _userRepository.AddUserAsync(newUser);
            return newUser;
        }

    }
}

