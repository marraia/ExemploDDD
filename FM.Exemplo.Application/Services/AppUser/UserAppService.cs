using FM.Exemplo.Application.Interfaces.Entities;
using FM.Exemplo.Application.Services.AppUser.Input;
using FM.Exemplo.Application.Services.AppUser.ViewModel;
using FM.Exemplo.Domain.Entities;
using FM.Exemplo.Domain.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FM.Exemplo.Application.Services.AppUser
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService _userDomainService;

        public UserAppService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }
        public async Task<UserViewModel> InsertUserAsync(UserInput input)
        {
            var user = new User(input.Nome, input.Email);
            user.AddPassword(input.Password);

            var obj = await _userDomainService.InsertUserAsync(user);
            return new UserViewModel()
            {
                Id = obj.Id,
                Email = obj.Email,
                Nome = obj.Name
            };
        }
    }
}
