using Microsoft.AspNetCore.Mvc;
using UBC_Gerenciador_de_Alunos_API.Dtos;
using UBC_Gerenciador_de_Alunos_API.Services;

namespace UBC_Gerenciador_de_Alunos_API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.Authenticate(loginDto.Username, loginDto.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}
