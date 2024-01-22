using Locadora.Dto;
using Locadora.Interface;
using Locadora.Models;
using Locadora.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UsuarioService _usuarioService;

        public UsuarioController(ITokenService tokenService, UsuarioService usuarioService)
        {
            _tokenService = tokenService;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(UsuarioDto dto, CancellationToken cancellationToken = default)
        {
            await _usuarioService.AdicionarUsuario(dto, cancellationToken);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Buscar(int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _usuarioService.BuscarUsuario(id, cancellationToken));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Remover(int id, CancellationToken cancellationToken = default)
        {
            await _usuarioService.RemoverUsuario(id, cancellationToken);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Editar(int id, UsuarioDto dto, CancellationToken cancellationToken = default)
        {
            await _usuarioService.EditarUsuario(id, dto, cancellationToken);
            return Ok();
        }

        [HttpGet("BuscaCompleta")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Todos(CancellationToken cancellationToken = default)
        {
            return Ok(await _usuarioService.BuscaCompleta(cancellationToken));
        }

        [HttpGet("DefinirAdministrador/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DefinirAdministrador(int id, CancellationToken cancellationToken = default)
        {
            await _usuarioService.DefinirAdministrador(id, cancellationToken);
            return Ok();
        }
    }
}
