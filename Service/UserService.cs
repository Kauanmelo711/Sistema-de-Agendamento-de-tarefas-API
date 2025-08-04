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
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            bool senhaCorreta = BCrypt.Net.BCrypt.Verify(senha, user.Senha);
            if (!senhaCorreta)
                throw new Exception("Senha incorreta");

            return user;
        }
        public async Task<User> RegisterUserAsync(RegisterDto dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

            var newUser = new User
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Senha = hashedPassword, 
                DataCadastro = DateTime.UtcNow
            };

            await _userRepository.AddUserAsync(newUser);
            return newUser;
        }
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("Usuário não encontrado");

            return new UserDto(user.Id, user.Nome, user.Email, user.Senha, user.DataCadastro);
        }

        public async Task UpdateUserAsync(int id, UserDto dto)
        {
            var user = new User
            {
                Id = id,
                Nome = dto.Nome!,
                Email = dto.Email!,
                Senha = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                DataCadastro = dto.DataCadastro ?? DateTime.UtcNow
            };
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

       
    }
}

