using Livros.DTOs;
using Livros.Models;
using Livros.Repositories;

namespace Livros.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _repository;

        public ProfessorService(IProfessorRepository repository) => _repository = repository;

        public async Task<IEnumerable<Professor>> ListarTodos() => await _repository.ListarTodos();

        public async Task<Professor?> BuscarPorId(int id) => await _repository.BuscarPorId(id);

        public async Task Criar(ProfessorDTO dto)
        {
            if (await _repository.ExisteComEmail(dto.Email))
                throw new Exception("Já existe um professor cadastrado com este e-mail.");
            var professor = new Professor { Nome = dto.Nome, Email = dto.Email };
            await _repository.Adicionar(professor);
        }

        public async Task Atualizar(int id, ProfessorDTO dto)
        {
            var professor = await _repository.BuscarPorId(id)
                ?? throw new Exception("Professor não encontrado");
            if (await _repository.ExisteComEmail(dto.Email, ignorarId: id))
                throw new Exception("Já existe outro professor cadastrado com este e-mail.");
            professor.Nome = dto.Nome;
            professor.Email = dto.Email;
            await _repository.Atualizar(professor);
        }

        public async Task Deletar(int id)
        {
            var professor = await _repository.BuscarPorId(id)
                ?? throw new Exception("Professor não encontrado");
            await _repository.Deletar(professor);
        }
    }
}
