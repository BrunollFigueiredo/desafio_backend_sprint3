using Livros.Models;

namespace Livros.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> ListarTodos();
        Task<Aluno?> BuscarPorId(int id);
        Task Adicionar(Aluno aluno);
        Task Atualizar(Aluno aluno);
        Task Deletar(Aluno aluno);
    }
}
