using Livros.Models;

namespace Livros.Repositories
{
    public interface INotaRepository
    {
        Task<IEnumerable<Nota>> ListarTodas();
        Task Adicionar(Nota nota);
    }
}
