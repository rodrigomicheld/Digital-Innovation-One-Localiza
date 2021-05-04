using curso.api.Domain.Entities;
using curso.api.Infraestrutura.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace curso.api.Infraestrutura.Data
{
    public class CursoDbContext : DbContext  
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Curso> Curso { get; set; }


    }
}
