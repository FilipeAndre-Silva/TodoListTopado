using FluentResults;
using User.Api.Dto.Request;
using User.Api.Dto.Response;

namespace User.Api.Interfaces
{
    public interface IUserService
    {
        Task<Result<CreateUserResponse>> CreateAsync(CreateUserRequest createDto);
        Task<Result> ActivationUserAccountAsync(ActivationUserRequest request);
    }
}