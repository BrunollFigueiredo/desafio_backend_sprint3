using Livros.Data;
using Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Livros.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly AppDbContext _context;

        public DisciplinaRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Disciplina>> ListarTodas() =>
            await _context.Disciplinas.ToListAsync();

        public async Task<Disciplina?> BuscarPorId(int id) =>
            await _context.Disciplinas.FirstOrDefaultAsync(d => d.Id == id);

        public async Task Adicionar(Disciplina disciplina)
        {
            await _context.Disciplinas.AddAsync(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Disciplina disciplina)
        {
            _context.Disciplinas.Remove(disciplina);
            await _context.SaveChangesAsync();
        }
    }
}
