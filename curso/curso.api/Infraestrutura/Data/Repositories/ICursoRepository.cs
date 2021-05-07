using curso.api.Domain.Entities;
using System.Collections.Generic;

namespace curso.api.Infraestrutura.Data.Repositories
{
    public interface ICursoRepository
    {
        public void Adicionar(Curso curso);
        public void Comit();
        public IList<Curso> ObterCursoUsuario(int codigousuario);
    }
}
