using Livros.DTOs;
using Livros.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _service;

        public AlunosController(IAlunoService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodos());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aluno = await _service.BuscarPorId(id);
            return aluno is null ? NotFound("Aluno não encontrado") : Ok(aluno);
        }

        [HttpGet("{id}/media")]
        public async Task<IActionResult> GetMedia(int id)
        {
            try
            {
                return Ok(await _service.CalcularMedia(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(AlunoDTO dto)
        {
            try
            {
                await _service.Criar(dto);
                return Ok("Aluno cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AlunoDTO dto)
        {
            try
            {
                await _service.Atualizar(id, dto);
                return Ok("Aluno atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return ex.Message.Contains("não encontrado")
                    ? NotFound(ex.Message)
                    : BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Deletar(id);
                return Ok("Aluno removido com sucesso");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
