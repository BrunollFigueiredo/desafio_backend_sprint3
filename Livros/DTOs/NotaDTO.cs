using System.ComponentModel.DataAnnotations;

namespace Livros.DTOs
{
    public class NotaDTO
    {
        [Required(ErrorMessage = "O ID do aluno é obrigatório")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "O ID da disciplina é obrigatório")]
        public int DisciplinaId { get; set; }

        [Range(0, 10, ErrorMessage = "A nota deve ser entre 0 e 10")]
        public decimal Valor { get; set; }
    }
}
