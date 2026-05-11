using Livros.DTOs;
using Livros.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinasController : ControllerBase
    {
        private readonly IDisciplinaService _service;

        public DisciplinasController(IDisciplinaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodas());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var disciplina = await _service.BuscarPorId(id);
            return disciplina is null ? NotFound("Disciplina não encontrada") : Ok(disciplina);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(DisciplinaDTO dto)
        {
            await _service.Criar(dto);
            return Ok("Disciplina cadastrada com sucesso");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DisciplinaDTO dto)
        {
            try
            {
                await _service.Atualizar(id, dto);
                return Ok("Disciplina atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Deletar(id);
                return Ok("Disciplina removida com sucesso");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
