using FM.Exemplo.Infrastructure.IoC.Context.Application;
using FM.Exemplo.Infrastructure.IoC.Context.Domain;
using FM.Exemplo.Infrastructure.IoC.Context.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FM.Exemplo.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void RootRegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            new ApplicationBootstraper().ChildServiceRegister(services);
            new DomainBootstraper().ChildServiceRegister(services);
            new RepositoryBootstrapper().ChildServiceRegister(services, configuration);
        }
    }
}
