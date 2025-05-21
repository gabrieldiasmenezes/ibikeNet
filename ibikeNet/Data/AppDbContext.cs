using Microsoft.EntityFrameworkCore;
using ibikeNet.Model;

namespace ibikeNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Monitoracao> Monitoracoes { get; set; }
        public DbSet<Patio> Patios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Administrador>()
                .Property(a => a.Status)
                .HasConversion<int>();
        }

    }
}
