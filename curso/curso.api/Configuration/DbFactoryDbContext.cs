using curso.api.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace curso.api.Configuration
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<CursoDbContext>
    {
        public CursoDbContext CreateDbContext(string[] args)
        {
            string mySqlConnection = "server=localhost;userid=dev;password=1234567;database=cursoDb";
            var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            optionsBuilder.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));

            CursoDbContext context = new CursoDbContext(optionsBuilder.Options);

            return context;
        }
    }
}
