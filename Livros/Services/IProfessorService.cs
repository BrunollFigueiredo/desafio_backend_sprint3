using Livros.DTOs;
using Livros.Models;

namespace Livros.Services
{
    public interface IProfessorService
    {
        Task<IEnumerable<Professor>> ListarTodos();
        Task<Professor?> BuscarPorId(int id);
        Task Criar(ProfessorDTO dto);
        Task Atualizar(int id, ProfessorDTO dto);
        Task Deletar(int id);
    }
}
