using FM.Exemplo.Application.Services.AppUser.Input;
using FM.Exemplo.Application.Services.AppUser.ViewModel;
using System.Threading.Tasks;

namespace FM.Exemplo.Application.Interfaces.Entities
{
    public interface IUserAppService
    {
        Task<UserViewModel> InsertUserAsync(UserInput input);
    }
}
