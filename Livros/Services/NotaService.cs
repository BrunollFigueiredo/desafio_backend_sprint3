using Livros.DTOs;
using Livros.Models;
using Livros.Repositories;

namespace Livros.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _repository;

        public NotaService(INotaRepository repository) => _repository = repository;

        public async Task<IEnumerable<Nota>> ListarTodas() => await _repository.ListarTodas();

        public async Task LancarNota(NotaDTO dto)
        {
            if (dto.Valor < 0 || dto.Valor > 10)
                throw new Exception("A nota deve ser entre 0 e 10");

            var nota = new Nota
            {
                AlunoId = dto.AlunoId,
                DisciplinaId = dto.DisciplinaId,
                Valor = dto.Valor
            };
            await _repository.Adicionar(nota);
        }
    }
}
