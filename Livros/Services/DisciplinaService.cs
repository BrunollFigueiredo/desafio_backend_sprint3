using Livros.DTOs;
using Livros.Models;
using Livros.Repositories;

namespace Livros.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _repository;

        public DisciplinaService(IDisciplinaRepository repository) => _repository = repository;

        public async Task<IEnumerable<Disciplina>> ListarTodas() => await _repository.ListarTodas();

        public async Task<Disciplina?> BuscarPorId(int id) => await _repository.BuscarPorId(id);

        public async Task Criar(DisciplinaDTO dto)
        {
            var disciplina = new Disciplina { Nome = dto.Nome, CargaHoraria = dto.CargaHoraria };
            await _repository.Adicionar(disciplina);
        }

        public async Task Atualizar(int id, DisciplinaDTO dto)
        {
            var disciplina = await _repository.BuscarPorId(id)
                ?? throw new Exception("Disciplina não encontrada");
            disciplina.Nome = dto.Nome;
            disciplina.CargaHoraria = dto.CargaHoraria;
            await _repository.Atualizar(disciplina);
        }

        public async Task Deletar(int id)
        {
            var disciplina = await _repository.BuscarPorId(id)
                ?? throw new Exception("Disciplina não encontrada");
            await _repository.Deletar(disciplina);
        }
    }
}
