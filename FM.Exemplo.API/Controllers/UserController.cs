using System.Threading.Tasks;
using FM.Exemplo.Application.Interfaces.Entities;
using FM.Exemplo.Application.Services.AppUser.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FM.Exemplo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        /// <summary>
        /// Método para inserir um usuário...
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserInput input)
        {
            return Created("", await _userAppService.InsertUserAsync(input));
        }
    }
}