using curso.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace curso.api.Infraestrutura.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDbContext _context;

        public CursoRepository(CursoDbContext context)
        {
            _context = context;
        }
        public void Adicionar(Curso curso)
        {
            _context.Curso.Add(curso);
        }

        public void Comit()
        {
            _context.SaveChanges();
        }

        public IList<Curso> ObterCursoUsuario(int codigousuario)
        {
            return _context.Curso.Include(i => i.Usuario).Where(w => w.CodigoUsuario == codigousuario).ToList();
        }
    }
}
