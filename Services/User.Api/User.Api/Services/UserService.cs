using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User.Api.Dto.Request;
using User.Api.Dto.Response;
using User.Api.Interfaces;
using User.Api.Models;

namespace User.Api.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private UserManager<CustomIdentityUser> _userManager;

        public UserService(IMapper mapper,
                           UserManager<CustomIdentityUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Result<CreateUserResponse>> CreateAsync(CreateUserRequest createDto)
        {
            CustomIdentityUser userIdentity = _mapper.Map<CustomIdentityUser>(createDto);
            
            var resultIdentity = await _userManager.CreateAsync(userIdentity, createDto.Password);

            if(resultIdentity.Succeeded)
            {
                var emailVerificationCode = await _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);

                var result = new CreateUserResponse
                {
                    UserId = userIdentity.Id,
                    EmailVerificationCode = emailVerificationCode
                };

                return Result.Ok(result);
            }

            return Result.Fail("Failed to register user");
        }

        public async Task<Result> ActivationUserAccountAsync(ActivationUserRequest request)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(usuario => usuario.Id == request.UserId);

            if(identityUser == null) return Result.Fail("User not found");

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.ActivationCode).Result;

            if(identityResult.Succeeded) return Result.Ok();

            return Result.Fail("Failed to activate user account");
        }
    }
}