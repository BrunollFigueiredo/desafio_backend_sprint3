using Livros.Models;

namespace Livros.Repositories
{
    public interface IDisciplinaRepository
    {
        Task<IEnumerable<Disciplina>> ListarTodas();
        Task<Disciplina?> BuscarPorId(int id);
        Task Adicionar(Disciplina disciplina);
        Task Atualizar(Disciplina disciplina);
        Task Deletar(Disciplina disciplina);
    }
}
