using Livros.DTOs;
using Livros.Models;

namespace Livros.Services
{
    public interface IDisciplinaService
    {
        Task<IEnumerable<Disciplina>> ListarTodas();
        Task<Disciplina?> BuscarPorId(int id);
        Task Criar(DisciplinaDTO dto);
        Task Atualizar(int id, DisciplinaDTO dto);
        Task Deletar(int id);
    }
}
