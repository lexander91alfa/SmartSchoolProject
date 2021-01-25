using System.Collections.Generic;

namespace SmartSchool.API.Model
{
    public class Aluno
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public int Telefone { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}