using Livros.DTOs;
using Livros.Repositories;
using Livros.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _service;

        public LivrosController(ILivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodos());

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(LivroDTO livroDTO)
        {
            try
            {
                await _service.Criar(livroDTO);
                return Ok("Livrocadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
