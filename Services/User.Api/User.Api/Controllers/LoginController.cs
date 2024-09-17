using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Api.Dto.Request;
using User.Api.Interfaces;

namespace User.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var result = await _loginService.LoginAsync(request);

            if (result.IsFailed) return Unauthorized(result.Errors);

            return Ok(result.Value);
        }

        [HttpPost("/logout")]
        [Authorize]
        public async Task<IActionResult> LogoutAsync()
        {
            var result = await _loginService.LogoutAsync();

            if (result.IsFailed) return Unauthorized(result.Errors);

            return Ok();
        }

        [HttpPost("/password-reset-code")]
        public async Task<IActionResult> GetPasswordResetCodeAsync(GetPasswordResetCodeRequest request)
        {
            var result = await _loginService.GetPasswordResetCodeAsync(request);

            if (result.IsFailed) return NotFound(result.Errors);

            return Ok(result.Value);
        }

        [HttpPost("/reset-password")]
        public async Task<IActionResult> ResetPasswordAsync(ResetUserPassworRequest request)
        {
            var result = await _loginService.ResetPasswordAsync(request);

            if (result.IsFailed) return Unauthorized(result.Errors);

            return Ok(result.Successes);
        }

        // TODO : Refresh Token  
    }
}