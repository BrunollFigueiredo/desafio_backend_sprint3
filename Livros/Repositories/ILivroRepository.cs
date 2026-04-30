using Livros.Models;

namespace Livros.Repositories
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> ListarTodos();
        Task Adicionar(Livro livro);
    }
}
