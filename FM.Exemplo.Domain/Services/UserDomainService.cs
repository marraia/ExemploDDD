using FM.Exemplo.Domain.Entities;
using FM.Exemplo.Domain.Interfaces.Entities;
using FM.Exemplo.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;
using System.Linq;
using FM.Exemplo.Domain.Core;

namespace FM.Exemplo.Domain.Services
{
    /// <summary>
    /// Estou usando um padrão de Arquitetura, que se chama DDD... estudar sobre esse tema..
    /// https://www.eduardopires.net.br/2014/10/tutorial-asp-net-mvc-5-ddd-ef-automapper-ioc-dicas-e-truques/
    /// </summary>
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Método que insere um usuário novo...
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<User> InsertUserAsync(User obj)
        {
            //TODO: Criar validações das propriedades do objeto...
            await _userRepository.InsertAsync(obj);
            return obj;
        }

        /// <summary>
        /// Método que verifica o usuário e a senha do usuário...
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> LoginAsync(string email, string password)
        {
            var obj = await _userRepository.GetAsync(a => a.Email == email);
            if (obj == null)
                return null;

            if (PasswordHasher.Verify(password, obj.FirstOrDefault().Password))
                return obj.FirstOrDefault();

            return null;
        }
    }
}
