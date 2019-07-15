using System.Threading.Tasks;
using FM.Exemplo.Application.Interfaces.Entities;
using FM.Exemplo.Application.Services.AppLogin.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FM.Exemplo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;
        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }


        /// <summary>
        /// Método de Login do usuario....
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginInput input)
        {
            var user = await _loginAppService.LoginAsync(input);

            if (user != null)
            {
                return Ok(new { token = user });
            }

            return Unauthorized();
        }
    }
}