using curso.api.Domain.Entities;

namespace curso.api.Infraestrutura.Data.Repositories
{
    public interface IUsuarioRepository
    {
        public void Adicionar(User user);
        public void Comit();
        public User ObterUsuario(string login);

        
    }
}
