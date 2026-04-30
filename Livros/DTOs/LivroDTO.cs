using System.ComponentModel.DataAnnotations;
namespace Livros.DTOs
{
    public class LivroDTO
    {
        [Required(ErrorMessage = "O titulo do livro é obrigatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="O titulo deve ter entre 3 e 100 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Autor { get; set; } = string.Empty;

        [Range(1300, 2026, ErrorMessage = "Anode publicação inválido.")]
        public int AnoPublicado { get; set; }
    }
}
