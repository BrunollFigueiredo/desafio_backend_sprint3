using Livros.Data;
using Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Livros.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Aluno>> ListarTodos() =>
            await _context.Alunos
                .Include(a => a.Notas)
                .ThenInclude(n => n.Disciplina)
                .ToListAsync();

        public async Task<Aluno?> BuscarPorId(int id) =>
            await _context.Alunos
                .Include(a => a.Notas)
                .ThenInclude(n => n.Disciplina)
                .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<bool> ExisteComEmail(string email, int? ignorarId = null) =>
            await _context.Alunos
                .AnyAsync(a => a.Email == email && a.Id != (ignorarId ?? 0));

        public async Task Adicionar(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }
}
