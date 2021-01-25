using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Model;
using SmartSchool.API.Repository.Intefaces;

namespace SmartSchool.API.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        # region methods: add, update, delete and commit

        public void Update<T>(T entity) where T : class
        {
            _dataContext.Update(entity);
        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }
        public bool Commit()
        {
            return (_dataContext.SaveChanges() > 0);
        }
        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }
        #endregion

        # region Aluno
        public Aluno GetAlunoById(int id, bool includeProfessor=false)
        {
            IQueryable<Aluno> query = _dataContext.Alunos;

            if(includeProfessor)
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);

            query = query.AsNoTracking().OrderBy(a => a.Id)
                .Where(al => al.Id == id);
            return query.FirstOrDefault();
        }

        public IEnumerable<Aluno> GetAlunos(bool includeProfessor=false)
        {
            IQueryable<Aluno> query = _dataContext.Alunos;

            if(includeProfessor)
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public IEnumerable<Aluno> GetAlunosByDisciplinaId(int id, bool includeProfessor=false)
        {
            IQueryable<Aluno> query = _dataContext.Alunos;

            if(includeProfessor)
                query = query.Include(a => a.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);

            query = query.AsNoTracking().OrderBy(a => a.Id)
                .Where(al => al.AlunosDisciplinas.Any(ad => ad.DisciplinaId == id));
            return query.ToArray();
        }

        # endregion

        #region Disciplina
        public Disciplina GetDisciplinaById(int id)
        {
            return _dataContext.Disciplinas.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Disciplina> GetDisciplinas()
        {
            return _dataContext.Disciplinas;
        }
        #endregion

        #region Professor
        public IEnumerable<Professor> GetProfessores(bool includeAluno = false)
        {
            IQueryable<Professor> query = _dataContext.Professores;

            if(includeAluno)
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(a => a.Aluno);

            query = query.AsNoTracking().OrderBy(p => p.Id);
            return query.ToArray();
        }

        public IEnumerable<Professor> GetProfessorByDisciplinaId(int id, bool includeAluno = false)
        {
            IQueryable<Professor> query = _dataContext.Professores;

            if(includeAluno)
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(a => a.Aluno);

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Disciplinas.Any(d => d.Id == id));
            return query.ToArray();
        }

        public Professor GetProfessorById(int id, bool includeAluno = false)
        {
            IQueryable<Professor> query = _dataContext.Professores;

            if(includeAluno)
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(a => a.Aluno);

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Id == id);
            return query.FirstOrDefault();
        }

        #endregion
        
    }
}