using System.Collections.Generic;
using SmartSchool.API.Model;

namespace SmartSchool.API.Repository.Intefaces
{
    public interface IUnitOfWork
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool Commit();

        // Alunos
        IEnumerable<Aluno> GetAlunos(bool includeProfessor=false);
        IEnumerable<Aluno> GetAlunosByDisciplinaId(int id, bool includeProfessor=false);
        Aluno GetAlunoById(int id, bool includeProfessor=false);
        
        // Professor
        IEnumerable<Professor> GetProfessores(bool includeAluno=false);
        IEnumerable<Professor> GetProfessorByDisciplinaId(int id, bool includeAluno=false);
        Professor GetProfessorById(int id, bool includeAluno=false);

        // Disciplina
        IEnumerable<Disciplina> GetDisciplinas();
        Disciplina GetDisciplinaById(int id);

    }
}