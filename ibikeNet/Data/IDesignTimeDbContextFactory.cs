using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ibikeNet.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Carrega a configuração do appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // pasta atual do projeto
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();

            // Pega a connection string do appsettings.json
            var connectionString = configuration.GetConnectionString("OracleConnection");

            builder.UseOracle(connectionString);

            return new AppDbContext(builder.Options);
        }
    }
}
