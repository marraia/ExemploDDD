using FM.Exemplo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FM.Exemplo.Infrastructure.Repositories.Mapping
{
    public class UserMapSqlServerConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigurationNameTable(builder);
            ConfigurationIdentity(builder);
        }
        public void ConfigurationNameTable(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Usuario", "dbo");
        }

        private void ConfigurationIdentity(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(a => a.Id)
                .UseSqlServerIdentityColumn();
        }

        public void ConfiguraPropriedades(EntityTypeBuilder<User> builder)
        {
            builder.Property(con => con.Id).HasColumnName("Id");
            builder.Property(con => con.Name).HasColumnName("Nome");
            builder.Property(con => con.Password).HasColumnName("Password");
            builder.Property(con => con.Email).HasColumnName("Email");
        }
    }
}
