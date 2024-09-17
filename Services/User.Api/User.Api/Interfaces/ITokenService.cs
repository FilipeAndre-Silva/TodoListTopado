using User.Api.Models;

namespace User.Api.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(CustomIdentityUser usuario);
    }
}