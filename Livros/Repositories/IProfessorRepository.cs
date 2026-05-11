using Livros.Models;

namespace Livros.Repositories
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> ListarTodos();
        Task<Professor?> BuscarPorId(int id);
        Task Adicionar(Professor professor);
        Task Atualizar(Professor professor);
        Task Deletar(Professor professor);
    }
}
