using FluentValidation;
using Microsoft.AspNetCore.Identity;
using WhatsApp.Common;
using WhatsApp.Entity.Models;
using WhatsApp.Services.Dtos.Account;

namespace WhatsApp.Services.Repositorys.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<RegisterUsers> _userManager;
        private readonly IValidator<RegisterUserRequestDto> _registerValidator;
        public AccountRepository(UserManager<RegisterUsers> userManager, IValidator<RegisterUserRequestDto> registerValidator)
        {
            _userManager = userManager;
            _registerValidator = registerValidator;
        }
        public async Task<Result<UserInfoResponseDto>> AuthenticateAsync(UserInfoRequestDto dto)
        {
            var result = new Result<UserInfoResponseDto>();

            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return result.AddError("Invalid credentials.", ResultTypes.InvalidData);

            var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordValid)
                return result.AddError("Invalid credentials.", ResultTypes.InvalidData);

            // Generate token or return basic user info
            var response = new UserInfoResponseDto
            {
                Email = user.Email,
                Name = user.Name,
                Id = user.Id,

            };

            result.Data = response;
            return result;
        }

        public async Task<Result<string>> RegisterAsync(RegisterUserRequestDto dto)
        {
            var result = new Result<string>();

            var validationResult = await _registerValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    result.Errors.Add(error.ErrorMessage);
                }
                result.ResultType = ResultTypes.InvalidData;
                return result;
            }

            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                return result.AddError("Email is already registered.", ResultTypes.InvalidData);

            var user = new RegisterUsers
            {
                UserName = dto.Email,
                Email = dto.Email,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber
            };

            var createResult = await _userManager.CreateAsync(user, dto.Password);

            if (!createResult.Succeeded)
            {
                foreach (var error in createResult.Errors)
                {
                    result.Errors.Add(error.Description);
                }
                result.ResultType = ResultTypes.InvalidData;
                return result;
            }

            result.Data = "User registered successfully";
            result.ResultType = ResultTypes.Success;
            return result;

        }
    }
}
