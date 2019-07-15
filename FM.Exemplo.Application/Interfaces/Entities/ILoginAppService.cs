using FM.Exemplo.Application.Services.AppLogin.Input;
using System.Threading.Tasks;

namespace FM.Exemplo.Application.Interfaces.Entities
{
    public interface ILoginAppService
    {
        Task<string> LoginAsync(LoginInput input);
    }
}
