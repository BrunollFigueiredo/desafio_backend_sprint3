using System.ComponentModel.DataAnnotations;

namespace Livros.DTOs
{
    public class DisciplinaDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Range(1, 400, ErrorMessage = "Carga horária deve ser entre 1 e 400 horas")]
        public int CargaHoraria { get; set; }
    }
}
