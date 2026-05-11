namespace Livros.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } = null!;
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; } = null!;
    }
}
