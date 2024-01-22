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
    public class LocacaoController : ControllerBase
    {
        private readonly LocacaoService _service;

        public LocacaoController(LocacaoService service)
        {
            _service = service;
        }

        [HttpPost("Alugar")]
        public async Task<IActionResult> Alugar(LocacaoDto dto, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Alugar(dto, cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Buscar(int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Buscar(id, cancellationToken));
        }

        [HttpPut("Entregar/{id}")]
        public async Task<IActionResult> Entregar(int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.Entregar(id, cancellationToken));
        }

        [HttpGet("BuscaCompleta/{idLocadora}")]
        public async Task<IActionResult> Todos(int idLocadora, CancellationToken cancellationToken = default)
        {
            return Ok(await _service.BuscaCompleta(idLocadora, cancellationToken));
        }
    }
}
