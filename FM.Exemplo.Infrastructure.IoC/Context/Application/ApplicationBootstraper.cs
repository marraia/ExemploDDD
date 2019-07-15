using FM.Exemplo.Application.Interfaces.Entities;
using FM.Exemplo.Application.Services.AppLogin;
using FM.Exemplo.Application.Services.AppUser;
using Microsoft.Extensions.DependencyInjection;

namespace FM.Exemplo.Infrastructure.IoC.Context.Application
{
    internal class ApplicationBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
        }
    }
}
