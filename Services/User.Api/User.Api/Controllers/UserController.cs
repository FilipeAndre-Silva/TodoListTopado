using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Api.Dto.Request;
using User.Api.Interfaces;

namespace User.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserRequest request)
        {
            var result = await _userService.CreateAsync(request);

            if(result.IsFailed) return NotFound(result.Errors);

            return Ok(result.Value);
        }

        [HttpGet("/activate-account")]
        public async Task<IActionResult> ActivateUserAccountAsync([FromQuery]ActivationUserRequest request)
        {
            var result = await _userService.ActivationUserAccountAsync(request);

            if(result.IsFailed) return NotFound(result.Errors);

            return Ok(result.Successes);
        }
    }
}