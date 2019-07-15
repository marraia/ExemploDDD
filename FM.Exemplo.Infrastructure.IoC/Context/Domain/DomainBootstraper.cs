using FM.Exemplo.Domain.Interfaces.Entities;
using FM.Exemplo.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FM.Exemplo.Infrastructure.IoC.Context.Domain
{
    internal class DomainBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUserDomainService, UserDomainService>();
        }
    }
}
