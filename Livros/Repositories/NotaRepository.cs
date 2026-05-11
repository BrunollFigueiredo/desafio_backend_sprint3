using Livros.Data;
using Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Livros.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly AppDbContext _context;

        public NotaRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Nota>> ListarTodas() =>
            await _context.Notas
                .Include(n => n.Aluno)
                .Include(n => n.Disciplina)
                .ToListAsync();

        public async Task Adicionar(Nota nota)
        {
            await _context.Notas.AddAsync(nota);
            await _context.SaveChangesAsync();
        }
    }
}
