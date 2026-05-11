using Livros.DTOs;
using Livros.Models;
using Livros.Repositories;

namespace Livros.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository) => _repository = repository;

        public async Task<IEnumerable<Aluno>> ListarTodos() => await _repository.ListarTodos();

        public async Task<Aluno?> BuscarPorId(int id) => await _repository.BuscarPorId(id);

        public async Task Criar(AlunoDTO dto)
        {
            var aluno = new Aluno { Nome = dto.Nome, Email = dto.Email };
            await _repository.Adicionar(aluno);
        }

        public async Task Atualizar(int id, AlunoDTO dto)
        {
            var aluno = await _repository.BuscarPorId(id)
                ?? throw new Exception("Aluno não encontrado");
            aluno.Nome = dto.Nome;
            aluno.Email = dto.Email;
            await _repository.Atualizar(aluno);
        }

        public async Task Deletar(int id)
        {
            var aluno = await _repository.BuscarPorId(id)
                ?? throw new Exception("Aluno não encontrado");
            await _repository.Deletar(aluno);
        }

        public async Task<object> CalcularMedia(int alunoId)
        {
            var aluno = await _repository.BuscarPorId(alunoId)
                ?? throw new Exception("Aluno não encontrado");

            if (!aluno.Notas.Any())
                return new { Aluno = aluno.Nome, Media = 0.0, Situacao = "Sem notas lançadas" };

            var media = aluno.Notas.Average(n => (double)n.Valor);
            var situacao = media >= 7.0 ? "Aprovado" : "Reprovado";

            return new { Aluno = aluno.Nome, Media = Math.Round(media, 2), Situacao = situacao };
        }
    }
}
