using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Libraly.Data.Context
{
    public class ApplicationContextFactory:IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; Database=LibrReact; User ID=postgres; Password=password",
                b => b.MigrationsAssembly("Libraly.Data"));
//ыы
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}