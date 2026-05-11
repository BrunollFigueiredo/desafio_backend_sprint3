using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Livros.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(
                "Server=localhost;Database=GestaoAcademicaDB;Uid=root;Pwd=Bruno2004;",
                new MySqlServerVersion(new Version(8, 0, 0)));
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
