using FM.Exemplo.Domain.Entities;
using FM.Exemplo.Infrastructure.Repositories.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FM.Exemplo.Infrastructure.Repositories.Context
{
    /// <summary>
    /// Estou usando para conectar na base de dados o EntityFramework...
    /// Desta forma, a parte de conexão com a base de dados, é totalmente separado da API...
    /// </summary>
    public class ExemploContext : DbContext
    {
        public ExemploContext (DbContextOptions<ExemploContext> options) 
            : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurationModelCreatingSqlServer(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void ConfigurationModelCreatingSqlServer(ModelBuilder modelBuilder)
        {
            modelBuilder
              .ApplyConfiguration(new UserMapSqlServerConfig());
        }
    }
}
