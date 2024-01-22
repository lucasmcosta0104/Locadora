using Locadora.Dto;
using Locadora.Interface;
using Locadora.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto, CancellationToken cancellationToken = default)
        {
            return Ok(await _tokenService.GerarToken(dto, cancellationToken));
        }
    }
}
