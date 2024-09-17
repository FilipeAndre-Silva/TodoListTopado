using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User.Api.Dto.Request;
using User.Api.Interfaces;
using User.Api.Models;

namespace User.Api.Services
{
    public class LoginService : ILoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;

        public LoginService(SignInManager<CustomIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Result<string>> LoginAsync(LoginRequest request)
        {
            var resultIdentity = await _signInManager.PasswordSignInAsync(request.Username,
                                                                          request.Password,
                                                                          false, false);
            if(resultIdentity.Succeeded)
            {
                var identityUser = await _signInManager.UserManager.Users.FirstOrDefaultAsync(usuario => 
                                        usuario.NormalizedUserName == request.Username.ToUpper()
                                        );

                Token token = TokenService.CreateToken(identityUser);

                return Result.Ok(token.Value);
            } 

            return Result.Fail("Failed to log in");
        }

        public async Task<Result> LogoutAsync()
        {
            var resultadoIdentity = _signInManager.SignOutAsync();
            if(resultadoIdentity.IsCompletedSuccessfully) return Result.Ok();
            
            return Result.Fail("Logout failed");
        }

        public async Task<Result<string>> GetPasswordResetCodeAsync(GetPasswordResetCodeRequest request)
        {
            CustomIdentityUser identityUser = await RecoverUserByEmail(request.Email);

            if (identityUser != null)
            {
                string recoveryCode = _signInManager
                    .UserManager.GeneratePasswordResetTokenAsync(identityUser).Result;
                return Result.Ok(recoveryCode);
            }

            return Result.Fail("Failed to request reset");
        }

        public async Task<Result> ResetPasswordAsync(ResetUserPassworRequest request)
        {
            CustomIdentityUser identityUser = await RecoverUserByEmail(request.Email);
            
            if (identityUser == null) return Result.Fail("E-mail not found");

            IdentityResult resultadoIdentity = _signInManager
                .UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password)
                .Result;

            if (resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Password reset successfully!");

            return Result.Fail("There was an error in the operation");
        }

        private async Task<CustomIdentityUser> RecoverUserByEmail(string email)
        {
            return await _signInManager
                            .UserManager
                            .Users
                            .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());
        }
    }
}