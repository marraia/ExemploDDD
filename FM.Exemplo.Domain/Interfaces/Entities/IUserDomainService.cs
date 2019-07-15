using FM.Exemplo.Domain.Entities;
using System.Threading.Tasks;

namespace FM.Exemplo.Domain.Interfaces.Entities
{
    public interface IUserDomainService
    {
        Task<User> InsertUserAsync(User obj);
        Task<User> LoginAsync(string email, string password);
    }
}
