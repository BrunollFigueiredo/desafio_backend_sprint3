using Livros.Repositories;
using Livros.Models;
using Livros.DTOs;
using Livros.Services;

namespace Livros.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;

        public LivroService(ILivroRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Livro>> ListarTodos() => 
            await _repository.ListarTodos();

        public async Task Criar(LivroDTO livroDTO)
        {
            if (livroDTO.AnoPublicado > DateTime.Now.Year)
                throw new Exception("Não é possivel publicar livros do futuro");

            var livro = new Livro
            {
                Titulo = livroDTO.Titulo,
                Autor = livroDTO.Autor,
                AnoPublicado = livroDTO.AnoPublicado,
            };

            await _repository.Adicionar(livro);
        
        
        }


    }
}
