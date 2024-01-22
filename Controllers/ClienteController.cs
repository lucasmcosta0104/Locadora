using Locadora.Dto;
using Locadora.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;
        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ClienteDto dto, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Adicionar(dto, cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Buscar(int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Buscar(id, cancellationToken));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Remover(int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Remover(id, cancellationToken));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Editar(int id, ClienteUpdateDto dto, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Editar(id, dto, cancellationToken));
        }

        [HttpGet("BuscaCompleta")]
        public async Task<IActionResult> Todos(CancellationToken cancellationToken = default)
        {
            return Ok(await _service.BuscaCompleta(cancellationToken));
        }

        [HttpPut("Bloquear/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Bloquear(int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Bloquear(id, cancellationToken));
        }

        [HttpPut("Desbloquear/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Desbloquear(int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Desbloquear(id, cancellationToken));
        }
    }
}
