using Microsoft.AspNetCore.Mvc;
using WhatsApp.Services.Dtos.Account;
using WhatsApp.Services.Repositorys.Account;

namespace WhatsApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountControlller : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountControlller(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserRequestDto registerUserRequestDto)
        {
            var result = await _accountRepository.RegisterAsync(registerUserRequestDto);
            return result.ToActionResult();
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserInfoRequestDto userInfoRequestDto)
        {
            var result = await _accountRepository.AuthenticateAsync(userInfoRequestDto);
            return result.ToActionResult();
        }
    }
}
