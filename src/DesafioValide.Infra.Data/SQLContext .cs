using DesafioValide.Domain.Entities;
using DesafioValide.Infra.Data.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesafioValide.Infra.Data
{
    public class SQLContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public SQLContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("SQLServer")!;
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        public override int SaveChanges()
        {
            var inserteds = ChangeTracker.Entries().Where(entry => entry.Entity is Entidade && entry.State == EntityState.Added);

            foreach (var inserted in inserteds)
            {
                Entidade entity = (Entidade)inserted.Entity;
                entity.CriadoEm = DateTime.Now;
   
            }
            return base.SaveChanges();
        }
    }
}
