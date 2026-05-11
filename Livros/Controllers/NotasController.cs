using Livros.DTOs;
using Livros.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly INotaService _service;

        public NotasController(INotaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.ListarTodas());

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(NotaDTO dto)
        {
            try
            {
                await _service.LancarNota(dto);
                return Ok("Nota lançada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
