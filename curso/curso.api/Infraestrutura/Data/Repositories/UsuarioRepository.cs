using curso.api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Infraestrutura.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CursoDbContext _context;

        public UsuarioRepository(CursoDbContext context)
        {
            _context = context;
        }

        public void Adicionar(User user)
        {
            _context.User.Add(user);
        }
        public void Comit()
        {
            _context.SaveChanges();
        }

        public User ObterUsuario(string login)
        {
            return _context.User.FirstOrDefault(u => u.Login == login);
        }
    }
}
