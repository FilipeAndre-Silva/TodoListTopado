using FluentResults;
using User.Api.Dto.Request;

namespace User.Api.Interfaces
{
    public interface ILoginService
    {
        Task<Result<string>> LoginAsync(LoginRequest request);
        Task<Result> LogoutAsync();
        Task<Result<string>> GetPasswordResetCodeAsync(GetPasswordResetCodeRequest request);
        Task<Result> ResetPasswordAsync(ResetUserPassworRequest request);
    }
}