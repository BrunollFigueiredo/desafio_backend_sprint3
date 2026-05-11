using Livros.Data;
using Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Livros.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDbContext _context;

        public ProfessorRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Professor>> ListarTodos() =>
            await _context.Professores
                .Include(p => p.Turmas)
                .ThenInclude(t => t.Disciplina)
                .ToListAsync();

        public async Task<Professor?> BuscarPorId(int id) =>
            await _context.Professores
                .Include(p => p.Turmas)
                .ThenInclude(t => t.Disciplina)
                .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> ExisteComEmail(string email, int? ignorarId = null) =>
            await _context.Professores
                .AnyAsync(p => p.Email == email && p.Id != (ignorarId ?? 0));

        public async Task Adicionar(Professor professor)
        {
            await _context.Professores.AddAsync(professor);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Professor professor)
        {
            _context.Professores.Update(professor);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Professor professor)
        {
            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
        }
    }
}
