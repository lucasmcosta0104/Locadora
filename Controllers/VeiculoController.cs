using Locadora.Dto;
using Locadora.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _service;
        public VeiculoController(VeiculoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Adicionar(VeiculoDto dto, CancellationToken cancellationToken = default)
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
        public async Task<IActionResult> Editar(int id, VeiculoEditDto dto, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Editar(id, dto, cancellationToken));
        }

        [HttpGet("BuscaCompleta/{idLocadora}")]
        public async Task<IActionResult> Todos(int idLocadora, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.BuscaCompleta(idLocadora, cancellationToken));
        }
    }
}
