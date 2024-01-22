using Locadora.Dto;
using Locadora.Interface;
using Locadora.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "master")]
    public class LocadoraController : ControllerBase
    {
        private readonly LocadoraModeloService _modeloService;

        public LocadoraController(LocadoraModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(LocadoraDto dto, CancellationToken cancellationToken = default)
        {
            await _modeloService.Adicionar(dto, cancellationToken);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Buscar(int id, CancellationToken cancellationToken = default)
        {
            return Ok(await _modeloService.Buscar(id, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id, CancellationToken cancellationToken = default)
        {
            await _modeloService.Remover(id, cancellationToken);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, LocadoraDto dto, CancellationToken cancellationToken = default)
        {
            await _modeloService.Editar(id, dto, cancellationToken);
            return Ok();
        }

        [HttpGet("BuscaCompleta")]
        public async Task<IActionResult> Todos(CancellationToken cancellationToken = default)
        {
            return Ok(await _modeloService.BuscaCompleta(cancellationToken));
        }
    }
}
