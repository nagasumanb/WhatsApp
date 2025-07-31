using WhatsApp.Common;
using WhatsApp.Services.Dtos.Account;

namespace WhatsApp.Services.Repositorys.Account
{
    public interface IAccountRepository
    {
        Task<Result<String>> RegisterAsync(RegisterUserRequestDto registerUserRequestDto);

        Task<Result<UserInfoResponseDto>> AuthenticateAsync(UserInfoRequestDto userInfoRequestDto);
    }
}
