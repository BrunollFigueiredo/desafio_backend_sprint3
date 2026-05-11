using Livros.DTOs;
using Livros.Models;

namespace Livros.Services
{
    public interface INotaService
    {
        Task<IEnumerable<Nota>> ListarTodas();
        Task LancarNota(NotaDTO dto);
    }
}
