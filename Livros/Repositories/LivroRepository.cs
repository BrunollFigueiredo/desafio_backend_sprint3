using Livros.Data;
using Livros.Models;
using Microsoft.EntityFrameworkCore;

namespace Livros.Repositories
{
    //Conexão com o banco
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;

        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        // buscar a informação
        public async Task<IEnumerable<Livro>> ListarTodos()
        {
            return await _context.Livros.ToListAsync();
        }

        //salvar no banco
        public async Task Adicionar(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
        }

    }
}
