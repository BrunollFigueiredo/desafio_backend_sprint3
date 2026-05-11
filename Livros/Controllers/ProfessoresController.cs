using Livros.DTOs;
using Livros.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessorService _service;

        public ProfessoresController(IProfessorService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodos());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var professor = await _service.BuscarPorId(id);
            return professor is null ? NotFound("Professor não encontrado") : Ok(professor);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(ProfessorDTO dto)
        {
            await _service.Criar(dto);
            return Ok("Professor cadastrado com sucesso");
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ProfessorDTO dto)
        {
            try
            {
                await _service.Atualizar(id, dto);
                return Ok("Professor atualizado com sucesso");
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
                return Ok("Professor removido com sucesso");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
