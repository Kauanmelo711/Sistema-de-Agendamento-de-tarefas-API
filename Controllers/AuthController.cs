using Microsoft.AspNetCore.Mvc;
using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.IService;
using sistemaDeTarefasT2m.Service;

namespace sistemaDeTarefasT2m.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.ValidateUserAsync(dto.Email, dto.Senha);
            if (user == null)
                return Unauthorized("Credenciais inválidas");

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = await _userService.RegisterUserAsync(dto);
            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }

    }
}
