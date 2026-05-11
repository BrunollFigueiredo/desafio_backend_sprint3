using Livros.DTOs;
using Livros.Models;

namespace Livros.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<Aluno>> ListarTodos();
        Task<Aluno?> BuscarPorId(int id);
        Task Criar(AlunoDTO dto);
        Task Atualizar(int id, AlunoDTO dto);
        Task Deletar(int id);
        Task<object> CalcularMedia(int alunoId);
    }
}
