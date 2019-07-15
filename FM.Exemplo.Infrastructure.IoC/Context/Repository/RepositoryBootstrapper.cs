using FM.Exemplo.Domain.Interfaces.Repositories;
using FM.Exemplo.Infrastructure.Repositories.Context;
using FM.Exemplo.Infrastructure.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FM.Exemplo.Infrastructure.IoC.Context.Repository
{
    internal class RepositoryBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection services, IConfiguration configuration)
        {
            //Cria conexão com a base de dados..
            services.AddDbContext<ExemploContext>(options =>
                    options.UseSqlServer(configuration.GetSection("ConnectionString").Value));

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
