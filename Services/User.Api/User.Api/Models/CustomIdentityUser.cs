using Microsoft.AspNetCore.Identity;

namespace User.Api.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public string Cpf { get; set; }
    }
}